using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using resturant.Helper;
using resturant.Models;
using resturant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly MyDbContext _context;
        public IWebHostEnvironment Environment;

        public InvoiceController(MyDbContext context, IWebHostEnvironment Environment)
        {
            _context = context;
            this.Environment = Environment;

        }




        [HttpPost("Invoice")]
        public async Task<JsonResult> Add([FromForm] AddInvoice inv)
        {
             var laststock = _context.StockItems.OrderBy(s => s.stockNumber).LastOrDefault();

            invoiceItems fd = new invoiceItems();
            // this will be Populate All Json To Single object And
            // You dont Need To Add some Constructors For Done this
            // JsonConvert.PopulateObject(inv.items, fd);

            var items= JsonConvert.DeserializeObject<List<invoiceItems>>(inv.items);

            var image = "";
            try
            {
                image = ImageHelper.SaveImage(inv.image, Environment);
            }
            catch (Exception)
            {

            }

            var invoice = new SupplyingInvoice()
            {
                invoiceDate = inv.invoiceDate,
               
                supplierId = inv.supplierId,
                Url= image

            };
            foreach (var item in items)
            {
                invoice.InvoiceDetails.Add(new InvoiceDetails
                {
                    Price=item.price,
                    discount=item.discount,
                    APDTotalCost=(item.price * item.count)-item.discount,
                    Count=item.count,
                    ItemId=item.itemId,
                    
                    
                });
            }
            foreach (var item in items)
            {
                var itemisexist = _context.StockItems.FirstOrDefault(s => s.ItemId == item.itemId);
                if (itemisexist != null)
                {
                    itemisexist.storage += item.count;
                }
                else
                {
                    _context.StockItems.Add(new StockItems
                    {
                        storage = item.count,
                        ItemId = item.itemId,
                        stockNumber= laststock != null ? laststock.stockNumber + 1 : 1,

                    });
                }
                
            }
            invoice.TotalOfPurchase = invoice.InvoiceDetails.Count > 0 ? invoice.InvoiceDetails.Sum(s => s.APDTotalCost) : 0;

            _context.SupplyingInvoice.Add(invoice);
            await _context.SaveChangesAsync();
            return new JsonResult("Success");
        }

        [HttpGet("Invoice")]
        public  IActionResult Get()
        {

            var invoices = _context.SupplyingInvoice.Include(i=>i.Supplier).Include(i=>i.InvoiceDetails)
                .Include(i=>i.InvoiceDetails).ThenInclude(s=>s.item).ThenInclude(s=>s.unit).Where(i=>!i.Deleted).Select(i => new
            {

               i.InvoiceId,
               i.TotalOfPurchase,
               
                i.invoiceDate,
                i.Url,
                supplier = new
                {
                    id=i.supplierId,
                    name=i.Supplier.supplierName,
                },
                i.InvoiceDetails
               




            }).ToList();
            return Ok(invoices);
        }




        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var item =  _context.SupplyingInvoice.Include(s=>s.InvoiceDetails).FirstOrDefault(obj => obj.InvoiceId == Id);

            if (item == null)
            {
                return BadRequest("Invalid item");
            }


            item.Deleted = true;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("Stock")]
        public  IActionResult GetStock()
        {

            var stock = _context.StockItems.Include(s=>s.item).Select(i => new
            {
               i.stockNumber,
               i.storage,
                i.item.Name,
                i.item.Id,
                

            }).ToList();
            return Ok(stock);
        }


        [HttpGet("GetItemsStock")]
        public IActionResult GetItemsStock()
        {

            var items = _context.StockItems.Include(s => s.item).Select(i => new
            {
                Id= i.item.Id,
                Name=i.item.Name,
                storage=i.storage,
                


            }).ToList();
            return Ok(items);
        }


        [HttpGet("test")]
        public  IActionResult test()
        {

            var stock = _context.InvoiceDetails.Include(s=>s.item).ToList();
            return Ok(stock);
        }


        [HttpPost("Consuming")]
        public async Task<IActionResult> Consuming([FromBody] sell model)
        {

            foreach (var item in model.items)
            {
                var getfromstock = _context.StockItems.Include(s=>s.item).FirstOrDefault(s => s.ItemId == item.itemId);

               
                if (getfromstock.storage < item.count)
                {
                    return BadRequest("Stock DoesNot Have Enough Storage of Item " + getfromstock.item.Name);
                }

                getfromstock.storage=getfromstock.storage - item.count;

                _context.Sales.Add(new Sales
                {
                    Count=item.count,
                    ItemId=item.itemId,
                    ConsumingDate= model.date,
 
                });
               await _context.SaveChangesAsync();
            }

            
            return Ok();
        }


        [HttpGet("Consuming")]
        public async Task<IActionResult> GetConsuming()
        {

            var items = _context.Sales.Include(s => s.item).ThenInclude(s=>s.unit).Select(i => new
            {
                i.ConsumingDate,
                i.Count,
                i.item,



            }).ToList();
            return Ok(items);

        }
        [HttpPost("FullReport")]
        public  IActionResult FullReport([FromBody] ViewModels.FullReport model)
        {

            var invoices = _context.SupplyingInvoice.Include(s => s.InvoiceDetails).ThenInclude(s=>s.item).ThenInclude(s=>s.unit).Where(s => s.invoiceDate >= model.From && s.invoiceDate <= model.To).Select(s => new
            {
                s.invoiceDate,
                Supplier = new
                {
                    id=s.Supplier.SupplierId,
                    name=s.Supplier.supplierName,
                },
                s.TotalOfPurchase,
                s.Url,
                s.Deleted,
                s.InvoiceDetails,
                



            }).ToList();

            var sales = _context.Sales.Include(s=>s.item).Where(s => s.ConsumingDate >= model.From && s.ConsumingDate <= model.To).Select(s => new
            {
                s.ConsumingDate,
                s.Count,
                s.item,
                

            }).ToList();


            var stock = _context.StockItems.Include(s=>s.item).ThenInclude(s=>s.unit).Select(s => new
            {
                s.item,
                s.stockNumber,
                s.storage,
                

            }).ToList();


            var result = new
            {
                invoices,
                sales,
                stock
            };
            return Ok(result);
        }




    }
}
