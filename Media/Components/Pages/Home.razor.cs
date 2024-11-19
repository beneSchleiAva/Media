using Evaluation.CustomRules;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using ModelInterface.Factories;

namespace Media.Components.Pages
{
    public partial class Home
    {
        public OrderPositonRule orderPositionRule = new();
        EventCallback<MouseEventArgs> AssignOrderPositionCallback => new(null, AssignOrderPositionToProduct);

        void AssignOrderPositionToProduct(MouseEventArgs args)
        {
            if (selectedProduct is not null && selectedPrice > 0)
            {

                var productPrice = ProductIdPríce[selectedProduct.Id];
                if (productPrice > 0)
                {

                    var position = OrderPositionFactory.Create(productId: selectedProduct.Id, productName: selectedProduct.Name, productPrice: productPrice, quantity: selectedQuantity, totalPrice: selectedPrice);
                    if (position is not null && orderPositionRule.Evaluate(position).Result)
                    {
                        orderPositions.Add(position);
                        InvokeAsync(StateHasChanged);
                    }
                }

            }
        }

    }
}
