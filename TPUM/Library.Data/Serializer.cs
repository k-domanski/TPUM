using System.IO;
using System.Xml.Serialization;
using Library.Data.Interface;
using Library.DTO;

namespace Library.Data
{
    public static class Serializer
    {
        public static string SerializeBook(IBook book)
        {
            BookDTO dto = new BookDTO
            {
                author = book.GetAuthor(),
                id = book.GetBookID(),
                isbn = book.GetISBN(),
                title = book.GetTitle(),
                isAvailable = book.IsAvailable()
            };
            XmlSerializer serializer = new XmlSerializer(typeof(BookDTO));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, dto);
                return writer.ToString();
            }
        }

        public static IBook DeserializeBook(string book)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BookDTO));
            using (StringReader reader = new StringReader(book))
            {
                BookDTO dto = serializer.Deserialize(reader) as BookDTO;
                if (dto == null)
                {
                    return null;
                }

                return new Book(dto.id, dto.isbn, dto.author, dto.author, dto.isAvailable);
            }
        }

        public static string SerializePerson(IPerson person)
        {
            PersonDTO dto = new PersonDTO
            {
                firstName = person.GetFirstName(),
                id = person.GetID(),
                surname = person.GetSurname()
            };
            XmlSerializer serializer = new XmlSerializer(typeof(PersonDTO));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, dto);
                return writer.ToString();
            }
        }

        public static IPerson DeserializePerson(string person)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PersonDTO));
            using (StringReader reader = new StringReader(person))
            {
                PersonDTO dto = serializer.Deserialize(reader) as PersonDTO;
                if (dto == null)
                {
                    return null;
                }

                return new Person(dto.id, dto.firstName, dto.surname);
            }
        }

        public static string SerializeLending(ILending lending)
        {
            LendingDTO dto = new LendingDTO
            {
                personID = lending.GetPersonID(),
                bookID = lending.GetBookID()
            };

            XmlSerializer serializer = new XmlSerializer(typeof(LendingDTO));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, dto);
                return writer.ToString();
            }
        }

        public static ILending DeserializeLending(string lending)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LendingDTO));
            using (StringReader reader = new StringReader(lending))
            {
                LendingDTO dto = serializer.Deserialize(reader) as LendingDTO;
                if (dto == null)
                {
                    return null;
                }

                return new Lending(dto.personID, dto.bookID);
            }
        }
    }
}