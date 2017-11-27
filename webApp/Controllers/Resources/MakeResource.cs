using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace webApp.Controllers.Resources
{
    public class MakeResource : KeyValuePairResource
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        public ICollection<KeyValuePairResource> Models { get; set; }

        public MakeResource()
        {
            Models = new Collection<KeyValuePairResource>();
        }

    }
}
