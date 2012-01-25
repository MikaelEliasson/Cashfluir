using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashfluir.Model
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public ICollection<string> AffectedUsersIds { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Id == ((Category)obj).Id;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
