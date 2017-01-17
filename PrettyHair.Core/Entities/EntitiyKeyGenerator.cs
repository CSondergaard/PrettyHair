using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHair.Core.Entities
{
    class EntityKeyGenerator
    {

        // static members
        private static volatile EntityKeyGenerator instance;
        private static object synchronizationRoot = new Object();

        public static EntityKeyGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (synchronizationRoot)
                    {
                        if (instance == null)
                        {
                            instance = new EntityKeyGenerator();
                        }
                    }
                }
                return instance;
            }
        }


        // instance variables
        private int nextKey;

        // private constructor
        private EntityKeyGenerator()
        {
        }

        // instance methods
        public virtual int NextKey
        {
            get
            {
                return ++nextKey;
            }
        }

        public virtual int RandomKey
        {
            get
            {
                Random rnd = new Random();
                nextKey = rnd.Next();
                return nextKey;
            }
        }

        public virtual int DateKey
        {
            get
            {
                DateTime date = DateTime.Now;
                nextKey = Convert.ToInt32(date.Ticks);
                return nextKey;
            }
        }
    }

    class KeyFactory
    {
        static public int GetKey(int choice)
        {
            int key = 0;
            switch(choice)
            {
                case 1:
                    key = EntityKeyGenerator.Instance.NextKey;
                    break;
                case 2:
                    key = EntityKeyGenerator.Instance.RandomKey;
                    break;
                case 3:
                    key = EntityKeyGenerator.Instance.DateKey;
                    break;

            }
            return key;
        }
    }
}
