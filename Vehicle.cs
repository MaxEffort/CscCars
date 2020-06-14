namespace CscCars
{
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public int TopSpeed { get; set; }

        private int _currentSpeed;
        public int CurrentSpeed
        {
            get
            {
                return _currentSpeed;
            }
            set
            {
                _currentSpeed = value;
            }
        }


        public Vehicle()
        {
            /*
                Initialization Code
             */

            Model = "Mini";
            CurrentSpeed = 10;
            TopSpeed = 235;
        }


        public void Accelerate(int accValue)
        {
            // readable way
            int newSpeed = CurrentSpeed + accValue;
            CurrentSpeed = newSpeed;

            // shorter
            CurrentSpeed += accValue;
        }

        public void Brake()
        {
            CurrentSpeed = 0;

        }
    }
}

/*
 byte --> number which tkes up 8 bits in memory 
 Int16 - short --> takes up 16 bits in memory
 Int32 - int   --> takes up 32 bits in memory
 Int64 - long  --> takes up 64 bits in memory


internal  - is available from the whole project
protected - is only available from derived classes and itself

abstract - we cannot make instances, but only inherit from this class
sealed - we cannot inherit, but only make instances
 */
