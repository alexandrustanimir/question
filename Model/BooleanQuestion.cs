using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Model
{
  
   public class BooleanQuestion : Question
    {
        public override QuestionType GetQuestionType()
        {
            return QuestionType.BooleanQuestion;
        }

        private string _trueOption;

        public string TrueOption
        {
            get { return _trueOption; }
            set { _trueOption = value; }
        }
        private string _falseOption;

        public string FalseOption
        {
            get { return _falseOption; }
            set { _falseOption = value; }
        }

        public override List<string> GetOptions()
        {
            return new List<string>() { TrueOption, FalseOption };
        }
       public BooleanQuestion(string trueOption="Yes",string falseOption="No"):base()
        {
            _trueOption = trueOption;
            _falseOption = falseOption;
        }
    }
}
