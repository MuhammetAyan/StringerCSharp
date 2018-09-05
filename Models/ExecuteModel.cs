using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ExecuteModel
    {
        public delegate void FinishDelegate();
        public event FinishDelegate Finish;

        public ExecuteModel()
        {
            i = 0;
            Words = new List<string>();
            ValuesIndex = new Dictionary<int, int>();
        }

        protected List<string> Words { get; set; }

        /// <summary>
        /// Key, Words için index tutar.
        /// Value ise örneğin '{0}' ifadesi için '0'ı tutar.
        /// </summary>
        protected Dictionary<int, int> ValuesIndex { get; set; }

        /// <summary>
        /// Son eklenen value index'i
        /// </summary>
        protected int i;

        /// <summary>
        /// Kelime olarak düz metin gir.
        /// </summary>
        /// <param name="word">Metin</param>
        public void AddWord(string word)
        {
            Words.Add(word);
        }

        /// <summary>
        /// Kelime olarak value gir.
        /// </summary>
        /// <param name="word">Value text'i</param>
        /// <param name="Value">Value index numarası - {0} için 0 -</param>
        public void AddWord(string word, int Value)
        {
            Words.Add(word);
            ValuesIndex.Add(Words.Count - 1, Value);
        }

        /// <summary>
        /// Kopyalanan veriyi yazdır. Words'ün üzerine yazar.
        /// </summary>
        /// <param name="value">Kopyalanan veri</param>
        public void AddValue(string value)
        {
            var wordIndices = ValuesIndex.Where(x => x.Value == i).Select(y => y.Key);
            foreach (var index in wordIndices)
                Words[index] = value;
            i++;
            if (i == ValuesIndex.Count)
            {
                Finish();
                i = 0;
            }
        }

        /// <summary>
        /// Oluşan veriyi getir.
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            string data = "";
            foreach (var word in Words)
                data += word;
            return data;
        }
    }
}
