using System;

namespace Lab2
{
    class WrappedBouquet : BouquetDecorator
    {
        public WrappedBouquet(Bouquet bouquet, BouquetWrapper wrapper) : base(bouquet)
        {
            mainConstructor(wrapper);
        }

        public WrappedBouquet(SignedBouquet bouquet, BouquetWrapper wrapper) : base(bouquet)
        {
            Postcard = bouquet.Postcard;
            mainConstructor(wrapper);
        }
        private void mainConstructor(BouquetWrapper wrapper)
        {
            this.Wrapper = wrapper;

            if (!Name.Contains("Wrapped"))
            {
                Name = Name.ToLower();
                Name = Name.Insert(0, "Wrapped");
            }
            switch (wrapper.Wrapper)
            {
                case Lab2.Wrapper.Organza:
                    Price += 10;
                    break;
                case Lab2.Wrapper.Paper:
                    Price += 5;
                    break;
                case Lab2.Wrapper.Tape:
                    Price += 3;
                    break;
            }
        }
    }
}
