using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Answer
    {
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private Guid _idQuestion;
        [DataMember]
        public Guid IdQuestion
        {
            get { return _idQuestion; }
            set { _idQuestion = value; }
        }
        private List<string> _answer;

        [DataMember]
        public List<string> AnswerList
        {
            get { return _answer; }
            set { _answer = value; }
        }

        public Answer()
        {
            AnswerList = new List<string>();
        }
    }
}
