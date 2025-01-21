using CQRSDemoNight.CQRSDesignPattern.Commands.ProductCommands;
using CQRSDemoNight.CQRSDesignPattern.Handlers.ProductHandlers;
using CQRSDemoNight.CQRSDesignPattern.Queries.ProductQueries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemoNight.Controllers
{
    public class ProductsController : Controller
    {
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        public ProductsController(GetProductByIdQueryHandler getProductByIdQueryHandler, GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler)
        {
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
        }

        public async Task<IActionResult> ProductList()
        {
            var value = await _getProductQueryHandler.Handle();
            return View(value);
        }

        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> UpdateProdut(UpdateProductCommand command)
        {
            await _updateProductCommandHandler.Handle(command);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            return View(await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id)));
        }
    }
}
