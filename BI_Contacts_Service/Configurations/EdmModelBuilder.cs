using BI_Contacts_Service.Models;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace BI_Contacts_Service.Configurations
{
    public static class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<ContactTypes>("ContactTypes");
            builder.EntitySet<CustomerContacts>("CustomerContacts");
            
            return builder.GetEdmModel();
        }
    }
}
