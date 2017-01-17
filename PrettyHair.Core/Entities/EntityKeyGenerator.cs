using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core.Entities
{
    class EntityKeyGenerator
    {

        private static volatile EntityKeyGenerator instance;

        public static EntityKeyGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EntityKeyGenerator();
                }
                return instance;
            }
        }
        private int nextKey;

        private EntityKeyGenerator()
        { }

        public virtual int NextKey
        {
            get
            {
                return ++nextKey;
            }
        }
    }
}