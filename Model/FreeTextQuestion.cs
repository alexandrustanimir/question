using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class FreeTextQuestion : Question
    {
        public override QuestionType GetQuestionType()
        {
            return QuestionType.FreeTextQuestion;
        }
        public override List<string> GetOptions()
        {
            return new List<string>();
        }
        public FreeTextQuestion()
            : base()
        {

        }
    }
}
