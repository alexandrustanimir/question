using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// this class will handle data containers for general CRUD operations
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// Retrieves collection of questions in JSON format 
        /// </summary>
        /// <returns></returns>
        public static List<Question> GetQuestions()
        {
            List<Question> result = new List<Question>();
            result.Add(new BooleanQuestion() { Id = Guid.NewGuid(), Content = "2 + 2 = 5 ? " });
            result.Add(new BooleanQuestion("True", "False"){ Id = Guid.NewGuid(), Content = "2 + 3 = 5 ? " });
            result.Add(new MultipleChoiceQuestion(new List<string>(){ "Li ","Be ", "Nq"}){ Id = Guid.NewGuid(), Content = "Choose which elements are in periodic table " });
            result.Add(new FreeTextQuestion() { Id = Guid.NewGuid(), Content = "Why so serious?" });
            return result;
        }
        /// <summary>
        /// this method should create a Json object by deserializing Answer parameter and POST the result 
        /// </summary>
        /// <param name="answer"></param>
        /// <returns>True if operation succeeded , false otherwise</returns>
        public static bool AddAnswer(Answer answer)
        {
            bool result = true;
            MemoryStream stream = new MemoryStream();
            try
            {
                DataContractJsonSerializer serializedContract = new DataContractJsonSerializer(typeof(Answer));
                serializedContract.WriteObject(stream, answer);

                Console.WriteLine(string.Format("Added answer "));
                answer.AnswerList.ForEach(delegate(string value) { Console.WriteLine(value); });
                Console.WriteLine(string.Format("For question {0} ", answer.IdQuestion));
                /// here we should create the HTTP request with stream content
            }
            catch (Exception ex )
            {
                result = false;
             
            }
            return result;
        }
    }
}
