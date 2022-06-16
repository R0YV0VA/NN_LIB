using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_lib
{
    class Layer
    {
        public Neuron[] neurons;
        public int count;
        public double Error;
        public double[] ErrorForRecalculate;
        public double Weight_delta;
        public Layer(int c)
        {
            count = c;
            neurons = new Neuron[count];
            ErrorForRecalculate = new double[count];
            for (int i = 0; i < count; i++)
            {
                neurons[i] = new Neuron();
            }
        }

        public double weight_sum = 0;
        public void Clearing()
        {
            Weight_delta = 0;
            Error = 0;

        }
        public void SetNeuroWeigh(int c, double w)
        {
            neurons[c].Weight = w;
        }
        public void SetNeuroImpulse(int c, double i)
        {
            neurons[c].Impulse = i;
        }
        public double GetNeuroWeigh(int c)
        {
            return neurons[c].Weight;
        }
        public void PrintNeuroWeigh()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(neurons[i].Weight);
            }
        }
        public double GetNeuroImpulse(int c)
        {
            return neurons[c].Impulse;
        }
        public void Summing()
        {
            weight_sum = 0;
            for (int i = 0; i < count; i++)
            {
                weight_sum += neurons[i].Weight * neurons[i].Impulse;
            }
        }
        public double Sigmoid()
        {
            Summing();
            return 1 / (1 + Math.Exp(-weight_sum));
        }

        public void RecalculateWeightsForEnd(double IdealOutput, double output, double N, int i)
        {
            //Summing();
            Clearing();
            Error = Sigmoid() - IdealOutput;
            Weight_delta = Error * (Sigmoid() * (1 - Sigmoid()));
            neurons[i].Weight = neurons[i].Weight - output * Weight_delta * N;
        }
        public void RecalculateWeights(double error, double N, int c)
        {
            //Summing();
            Clearing();
            Weight_delta = error * (Sigmoid() * (1 - Sigmoid()));
            neurons[c].Weight = neurons[c].Weight - neurons[c].Impulse * Weight_delta * N;
        }
        public double GetError(int i)
        {
            ErrorForRecalculate[i] = neurons[i].Weight * Weight_delta;
            return ErrorForRecalculate[i];

        }
    }
}
