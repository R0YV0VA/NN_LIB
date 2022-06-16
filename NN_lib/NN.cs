using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_lib
{
    class NN
    {
        private Layer[] InputToHidden;
        private HiddenLayers[] hiddenLayers;
        private Layer[] HiddenToOutput;

        public void CreateInputLayer(int count)
        {
            InputToHidden = new Layer[count];
        }
        public void CreateHiddenLayers(int layer_count,int count)
        {
            hiddenLayers = new HiddenLayers[layer_count];
        }
        public void SetCountForHidLayer(int i,int count)
        {
            hiddenLayers[i].setCount(count);
        }
        public void CreateoutputLayer(int count)
        {
            InputToHidden = new Layer[count];
        }
    }

    class HiddenLayers
    {
        public Layer[] HiddenToHidden { get; set; }
        public void setCount(int count)
        {
            HiddenToHidden = new Layer[count];
        }
    }
}
