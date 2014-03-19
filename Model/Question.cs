using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// This is an abstractization of a question
    /// </summary>
    /// 
    [DataContract]
    public abstract class Question
    {
        private Guid _id;
        /// <summary>
        /// Each question should have an unique identifier
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _content;
        /// <summary>
        /// This is the formulation of a question
        /// </summary>
        [DataMember]
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// returning type of a question ( boolean , multiple choices or free text )
        /// </summary>
        /// <returns>Enum</returns>
        public abstract QuestionType GetQuestionType();
        /// <summary>
        /// Constructs a list of possible answers ( if any )
        /// </summary>
        /// <returns>A list of string with possible answers</returns>
        public abstract List<string> GetOptions();
        public Question()
        {
            _id = Guid.NewGuid();
            Content = "This is a sample questions";
        }

    }
}
