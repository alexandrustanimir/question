using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MultipleChoiceQuestion : Question
    {
        private List<string> _answers;
        public List<string> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }
        public override QuestionType GetQuestionType()
        {
            return QuestionType.MultipleChoiceQuestion;
        }
        public override List<string> GetOptions()
        {
            return Answers;
        }
        public MultipleChoiceQuestion(List<string> answers):base()
        { if(answers==null)
        {
            answers = new List<string>();
        }
            _answers = answers;
        }
    }
}
