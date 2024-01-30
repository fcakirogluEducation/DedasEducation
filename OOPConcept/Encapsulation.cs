namespace OOPConcept
{
    public class Encapsulation
    {
        public Encapsulation()
        {
        }
    }


    public class ProductHelper
    {
        private int _kdv; //field


        public int Kdv
        {
            get => _kdv;
            set
            {
                if (value >= 20 || value <= 0)
                {
                    throw new Exception("Kdv değeri 1 ile 20  arasında olmalıdır");
                }

                _kdv = value;
            }
        } //property

        public void SetKdv(int kdv)
        {
            if (kdv >= 20 || kdv <= 0)
            {
                throw new Exception("Kdv değeri 1 ile 20  arasında olmalıdır");
            }

            _kdv = kdv;
        }

        public int GetKdv()
        {
            return _kdv;
        }


        private void Method1()
        {
        }

        public void Method2()
        {
            Method1();
        }
    }
}