using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MybookingpalRestful.StepDefinitions
{
    [Binding]
    public class BookinAPISteps
    {
        [Given(@"I searched for products with parameters")]
        public void GivenISearchedForProductsWithParameters(Table table)
        {
            var instance = SearchParams.Create(table);
            ScenarioContext.Current.Add("SearchParams", instance);
        }
        
        [When(@"I look at (.*) product")]
        public void WhenILookAtApartmentBouchardonProduct(string productTitle)
        {
            var parameters = ScenarioContext.Current.Get<SearchParams>("SearchParams");
            var restInteraction = new Interaction();
            var response = restInteraction.GetProductsByCriteria(parameters);

            ProductsContainer.Quote product =response.search_response.search_quotes.quote.FirstOrDefault(
                    quote => quote.productname == productTitle);
            ScenarioContext.Current.Add("Product",product);
        }
        
        [Then(@"I can see price in results list is equal to price in product details")]
        public void ThenICanSeePriceInResultsListIsEqualToPriceInProductDetails()
        {
            var product = ScenarioContext.Current.Get<ProductsContainer.Quote>("Product");
            Assert.NotNull(product,"Product not found");
            
            var parameters = ScenarioContext.Current.Get<SearchParams>("SearchParams");
            var restInteraction = new Interaction();
            var productDetails = restInteraction.GetProductDetails(product.productid, parameters);

            Assert.AreEqual(product.cost, productDetails.quotes.price);
        }
    }
}
