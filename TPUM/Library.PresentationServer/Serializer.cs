using System.IO;
using System.Xml.Serialization;
using Library.DTO;
using Library.LogicServer;
using Library.LogicServer.Interface;

namespace Library.PresentationServer
{
    public static class Serializer
    {
        public static string SerializeBook(IBookInfo book)
        {
            BookDTO dto = new BookDTO
            {
                author = book.author,
                id = book.id,
                isbn = book.isbn,
                title = book.title,
                isAvailable = book.isAvailable
            };
            XmlSerializer serializer = new XmlSerializer(typeof(BookDTO));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, dto);
                return writer.ToString();
            }
        }

        public static IBookInfo DeserializeBook(string book)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BookDTO));
            using (StringReader reader = new StringReader(book))
            {
                BookDTO dto = serializer.Deserialize(reader) as BookDTO;
                if (dto == null)
                {
                    return null;
                }

                return new BookInfo
                {
                    author = dto.author,
                    id = dto.id,
                    isAvailable = dto.isAvailable,
                    isbn = dto.isbn,
                    title = dto.title
                };
            }
        }

        public static string SerializePerson(IPersonInfo person)
        {
            PersonDTO dto = new PersonDTO
            {
                firstName = person.firstName,
                id = person.id,
                surname = person.surname
            };
            XmlSerializer serializer = new XmlSerializer(typeof(PersonDTO));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, dto);
                return writer.ToString();
            }
        }

        public static IPersonInfo DeserializePerson(string person)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PersonDTO));
            using (StringReader reader = new StringReader(person))
            {
                PersonDTO dto = serializer.Deserialize(reader) as PersonDTO;
                if (dto == null)
                {
                    return null;
                }

                return new PersonInfo { firstName = dto.firstName, id = dto.id, surname = dto.surname };
            }
        }

        public static string SerializeLending(ILendingInfo lending)
        {
            LendingDTO dto = new LendingDTO
            {
                personID = lending.personID,
                bookID = lending.bookID
            };

            XmlSerializer serializer = new XmlSerializer(typeof(LendingDTO));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, dto);
                return writer.ToString();
            }
        }

        public static ILendingInfo DeserializeLending(string lending)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LendingDTO));
            using (StringReader reader = new StringReader(lending))
            {
                LendingDTO dto = serializer.Deserialize(reader) as LendingDTO;
                if (dto == null)
                {
                    return null;
                }

                return new LendingInfo { bookID = dto.bookID, personID = dto.personID };
            }
        }
    }
}