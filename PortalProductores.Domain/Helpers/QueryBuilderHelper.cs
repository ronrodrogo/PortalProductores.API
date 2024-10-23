using System.Text;

namespace PortalProductores.Domain.Helpers
{
    public static class QueryBuilderHelper
    {
        public static void AddFilterCondition(
            this StringBuilder query,
            string condition,
            bool applyCondition
        )
        {
            if (applyCondition)
            {
                query.Append(condition);
            }
        }
    }
}
