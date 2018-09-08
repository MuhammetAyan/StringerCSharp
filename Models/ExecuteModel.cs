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

        private bool isRecuriveBegining;
        /// <summary>
        /// Yinelemenin sürüp sürmediğini döndürür.
        /// </summary>
        public bool IsRecuriveBegining
        {
            get { return isRecuriveBegining; }
        }

        private bool isRecuriveBegined;
        /// <summary>
        /// Modelin yenilemeye sahip olup olmadığını döndürür.
        /// </summary>
        public bool IsRecuriveBegined
        {
            get { return isRecuriveBegined; }
        }

        /// <summary>
        /// Yenilenen alanların getdata verilerini saklar.
        /// </summary>
        private string RecuriveTemp;

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
        /// Yenilenen alanları tutar. Key indisi verir. Value yenilenen alanın modelini verir.
        /// </summary>
        protected KeyValuePair<int, ExecuteModel> Recurives { get; set; }

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
            if (IsRecuriveBegining)
                Recurives.Value.AddWord(word);
            else
                Words.Add(word);
        }

        /// <summary>
        /// Kelime olarak value gir.
        /// </summary>
        /// <param name="word">Value text'i</param>
        /// <param name="Value">Value index numarası - {0} için 0 -</param>
        public void AddWord(string word, int Value)
        {
            if (IsRecuriveBegining)
            {
                Recurives.Value.AddWord(word, Value);
            }
            else
            {
                Words.Add(word);
                ValuesIndex.Add(Words.Count - 1, Value);
            }

        }

        /// <summary>
        /// Kopyalanan veriyi yazdır. Words'ün üzerine yazar.
        /// </summary>
        /// <param name="value">Kopyalanan veri</param>
        public void AddValue(string value)
        {
            //Gelen value nun hangi indis olduğunu sapta = i
            //Bu indisin hangi modelde olduğunu bul
            //Bu modelde olup olmadığı:
            bool InThisModel = ValuesIndex.Values.Contains(i);
            //Eğer çift model varsa ve bu modelde değilse
            if (IsRecuriveBegined && !InThisModel)
            {
                Recurives.Value.AddValue(value); // Recurive modele ekle
                i++; //Bu model için de value artmış sayılır.
            }
            else //Bu modeldeyse
            {
                var wordIndices = ValuesIndex.Where(x => x.Value == i).Select(y => y.Key);
                foreach (var index in wordIndices)
                    Words[index] = value;
                i++;
                //Recurive model varsa
                if (IsRecuriveBegined)
                    Recurives.Value.i++; //Recurive model için de değer arttır.
                //Recurive yokken model tek başına bitebilir.
                if (!IsRecuriveBegined && i > ValuesIndex.Values.Max())
                {
                    Finish();
                    i = ValuesIndex.Values.Min();
                }
            }

        }

        /// <summary>
        /// Yenileme moduna giriş yap.
        /// </summary>
        /// <param name="model">Yenileme modeli</param>
        public void BeginRecurives(ExecuteModel model)
        {
            Recurives = new KeyValuePair<int, ExecuteModel>(Words.Count, model);
            model.Finish += Recurive_Finish;
            isRecuriveBegining = true;
            isRecuriveBegined = true;
        }

        private void Recurive_Finish()
        {
            RecuriveTemp += Recurives.Value.GetData();
            Finish();
        }

        /// <summary>
        /// Yenileme modundan çıkış yap.
        /// </summary>
        public void CloseRecurives()
        {
            isRecuriveBegining = false;
        }

        /// <summary>
        /// Oluşan veriyi getir.
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            int ii = 0;
            string data = "";
            for (int I = 0; I < Words.Count; I++)
            {
                if (IsRecuriveBegined && ii == Recurives.Key)
                {
                    data += RecuriveTemp;
                    I--;
                }
                else
                    data += Words[I];
                ii++;
            }
            return data;
        }

        /// <summary>
        /// Toplam yerleştirilecek value sayısı
        /// </summary>
        /// <returns></returns>
        public int GetValueCount
        {
            get
            {
                if (IsRecuriveBegined)
                    return ValuesIndex.Values.Distinct().Count() + Recurives.Value.GetValueCount;
                else
                    return ValuesIndex.Count;
            }
        }

    }
}
