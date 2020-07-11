using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class SignedBouquet : BouquetDecorator
    {
        public SignedBouquet(Bouquet bouquet, Postcard postcard) : base(bouquet)
        {
            mainConstructor(postcard);
        }

        public SignedBouquet(WrappedBouquet bouquet, Postcard postcard) : base(bouquet)
        {
            Wrapper = bouquet.Wrapper;
            mainConstructor(postcard);
        }

        private void mainConstructor(Postcard postcard)
        {
            this.Postcard = postcard;
            if (!Name.Contains("with postcard"))
            {
                Name = Name.Insert(Name.Length - 1, " with postcard ");
            }
            Price += 10;
        }

    }
}
