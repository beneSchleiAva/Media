using Evaluation.CustomRules;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using ModelInterface.Factories;

namespace Media.Components.Pages
{
    public partial class Home
    {
        EventCallback<MouseEventArgs> AssignOrderPositionCallback => new(null, AssignOrderPositionToProduct);

        async Task AssignOrderPositionToProduct(MouseEventArgs args)
        {
            if (selectedProduct is not null && await ProductRule.Evaluate(selectedProduct))
            {
                var position = OrderPositionFactory.Create(product: selectedProduct, quantity: selectedQuantity, totalPrice: selectedPrice);
                if (position is not null && OrderPositonRule.Evaluate(position).Result)
                {
                    orderPositions.Add(position);
                    await InvokeAsync(StateHasChanged);
                }
            }
        }

    }
}
