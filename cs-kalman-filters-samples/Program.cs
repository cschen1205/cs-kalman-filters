using System;

namespace KalmanFilters
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFilter1D();
            TestFilter2D();
        }

        public static void TestFilter1D()
        {
            double[] measurements = new double[5] { 5.0, 6.0, 7.0, 9.0, 10.0 };
            double[] motion = new double[5] { 1.0, 1.0, 2.0, 1.0, 1.0 };
            double measurement_sigma = 4.0;
            double motion_sigma = 2.0;
            double mu = 0;
            double sigma = 10000;

            KalmanFilter1D filter = new KalmanFilter1D(mu, sigma, measurement_sigma, motion_sigma);

            for (int t = 0; t < measurements.Length; ++t)
            {
                filter.Update(measurements[t]);
                filter.Predict(motion[t]);
                Console.WriteLine(filter.BeliefDistributionDescription);
            }
        }



        public static void TestFilter2D()
        {
            double[] measurements = new double[3] { 1, 2, 3 }; //measurement of locations at t = 1, 2, 3

            //apply kalman filter to predict the velocity and location at t = 4
            KalmanFilter2D filter = new KalmanFilter2D();

            for (int t = 0; t < measurements.Length; ++t)
            {
                filter.Update(measurements[t]);
                filter.Predict();
            }

            Console.WriteLine("x: {0}", filter.StateDescription);
            Console.WriteLine("P: {0}", filter.UncertaintyDescription);

        }
    }
}
