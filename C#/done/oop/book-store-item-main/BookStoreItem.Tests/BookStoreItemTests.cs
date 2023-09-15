using System.Reflection;
using NUnit.Framework;

namespace BookStoreItem.Tests
{
    [TestFixture]
    public class BookStoreItemTests
    {
        private static readonly object[][] ConstructorData =
        {
            new object[]
            {
                new[] { typeof(string), typeof(string), typeof(string), typeof(string) },
            },
            new object[]
            {
                new[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) },
            },
            new object[]
            {
                new[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(decimal), typeof(string), typeof(int) },
            },
            new object[]
            {
                new[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(decimal), typeof(string), typeof(int) },
            },
        };

        private static readonly object[][] BookStoreItemWithPublishedArgumentIsInvalidData =
        {
            new object[]
            {
                string.Empty, "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "authorName",
            },
            new object[]
            {
                "          ", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "authorName",
            },
            new object[]
            {
                "Edgar Allan Poe", string.Empty, "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "title",
            },
            new object[]
            {
                "Edgar Allan Poe", "  ", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "title",
            },
            new object[]
            {
                "Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", string.Empty, "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "publisher",
            },
            new object[]
            {
                "Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "     ", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "publisher",
            },
            new object[]
            {
                "Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", string.Empty, new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "isbn",
            },
            new object[]
            {
                "Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "      ", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "isbn",
            },
            new object[]
            {
                "Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, string.Empty, 3, "currency",
            },
            new object[]
            {
                "Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "     ", 3, "currency",
            },
        };

        private static readonly object[][] BookStoreItemWithIsniAndPublishedArgumentIsInvalidData =
        {
            new object[]
            {
                string.Empty, "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "authorName",
            },
            new object[]
            {
                "      ", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "authorName",
            },
            new object[]
            {
                "Edgar Allan Poe", string.Empty, "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "isni",
            },
            new object[]
            {
                "Edgar Allan Poe", "         ", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "isni",
            },
            new object[]
            {
                "Edgar Allan Poe", "0000000121354025", string.Empty, "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "title",
            },
            new object[]
            {
                "Edgar Allan Poe", "0000000121354025", "      ", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "title",
            },
            new object[]
            {
                "Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", string.Empty, "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "publisher",
            },
            new object[]
            {
                "Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "         ", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "publisher",
            },
            new object[]
            {
                "Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", string.Empty, new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "isbn",
            },
            new object[]
            {
                "Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "                      ", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, "isbn",
            },
            new object[]
            {
                "Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, string.Empty, 3, "currency",
            },
            new object[]
            {
                "Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "   ", 3, "currency",
            },
        };

        private static readonly object?[][] BookStoreItemWithPublishedData =
        {
            new object?[]
            {
                "Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3,
            },
            new object?[]
            {
                "Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", null, "Hardcover", 10.11m, "USD", 3,
            },
        };

        private static readonly object?[][] BookStoreItemWithIsniAndPublishedData =
        {
            new object?[]
            {
                "Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3,
            },
            new object?[]
            {
                "Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", null, "Hardcover", 10.11m, "USD", 3,
            },
        };

        private static readonly object[][] ToStringData =
        {
            new object[]
            {
                "Complete Stories and Poems of Edgar Allan Poe, Edgar Allan Poe, ISNI IS NOT SET, 0.00 USD, 0", new object[] { "Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077" },
            },
            new object[]
            {
                "Complete Stories and Poems of Edgar Allan Poe, Edgar Allan Poe, 0000000121354025, 0.00 USD, 0", new object[] { "Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077" },
            },

            new object[]
            {
                "Complete Stories and Poems of Edgar Allan Poe, Edgar Allan Poe, ISNI IS NOT SET, 10.11 USD, 3", new object[] { "Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 10.11m, "USD", 3, },
            },
            new object[]
            {
                "Complete Stories and Poems of Edgar Allan Poe, Edgar Allan Poe, 0000000121354025, \"123,456,789.12 EUR\", 123456789", new object[] { "Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", new DateTime(1966, 11, 18), "Hardcover", 123456789.123m, "EUR", 123456789, },
            },
        };

        private static readonly object[][] HasPrivateStaticMethodData =
        {
            new object[]
            {
                "ValidateIsni", new object[] { "0000000121354025" }, true,
            },
            new object[]
            {
                "ValidateIsni", new object[] { string.Empty }, false,
            },
            new object[]
            {
                "ValidateIsni", new object[] { "000000012135402" }, false,
            },
            new object[]
            {
                "ValidateIsni", new object[] { "00000001213540256" }, false,
            },
            new object[]
            {
                "ValidateIsbn", new object[] { "1617294534" }, true,
            },
            new object[]
            {
                "ValidateIsbn", new object[] { string.Empty }, false,
            },
            new object[]
            {
                "ValidateIsbn", new object[] { "161729453" }, false,
            },
            new object[]
            {
                "ValidateIsbn", new object[] { "16172945345" }, false,
            },
            new object[]
            {
                "ValidateIsbnChecksum", new object[] { "1617294535" }, true,
            },
            new object[]
            {
                "ValidateIsbnChecksum", new object[] { "1617294534" }, false,
            },
        };

        private Type? classType;

        [TestCase("", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", "authorName")]
        [TestCase("   ", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", "authorName")]
        [TestCase("Edgar Allan Poe", "", "Doubleday", "0385074077", "title")]
        [TestCase("Edgar Allan Poe", "      ", "Doubleday", "0385074077", "title")]
        [TestCase("Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "", "0385074077", "publisher")]
        [TestCase("Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "    ", "0385074077", "publisher")]
        [TestCase("Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "", "isbn")]
        [TestCase("Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "                         ", "isbn")]
        public void BookStoreItem_ArgumentIsInvalid_ThrowsArgumentException(string authorName, string title, string publisher, string isbn, string parameterName)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                try
                {
                    // Act
                    _ = new BookStoreItem(authorName: authorName, title: title, publisher: publisher, isbn: isbn);
                }
                catch (ArgumentException e)
                {
                    Assert.That(e.ParamName, Is.EqualTo(parameterName));
                    throw;
                }
            });
        }

        [TestCase("", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", "authorName")]
        [TestCase("    ", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", "authorName")]
        [TestCase("Edgar Allan Poe", "", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", "isni")]
        [TestCase("Edgar Allan Poe", "     ", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", "isni")]
        [TestCase("Edgar Allan Poe", "0000000121354025", "", "Doubleday", "0385074077", "title")]
        [TestCase("Edgar Allan Poe", "0000000121354025", "       ", "Doubleday", "0385074077", "title")]
        [TestCase("Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "", "0385074077", "publisher")]
        [TestCase("Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "    ", "0385074077", "publisher")]
        [TestCase("Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "", "isbn")]
        [TestCase("Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "              ", "isbn")]
        public void BookStoreItem_WithIsni_ArgumentIsInvalid_ThrowsArgumentException(string authorName, string isni, string title, string publisher, string isbn, string parameterName)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                try
                {
                    // Act
                    _ = new BookStoreItem(authorName: authorName, isni: isni, title: title, publisher: publisher, isbn: isbn);
                }
                catch (ArgumentException e)
                {
                    Assert.That(e.ParamName, Is.EqualTo(parameterName));
                    throw;
                }
            });
        }

        [TestCaseSource(nameof(BookStoreItemWithPublishedArgumentIsInvalidData))]
        public void BookStoreItem_WithPublished_ArgumentIsInvalid_ThrowsArgumentException(string authorName, string title, string publisher, string isbn, DateTime published, string bookBinding, decimal price, string currency, int amount, string parameterName)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                try
                {
                    // Act
                    _ = new BookStoreItem(authorName: authorName, title: title, publisher: publisher, isbn: isbn, published: published, bookBinding: bookBinding, price: price, currency: currency, amount: amount);
                }
                catch (ArgumentException e)
                {
                    Assert.That(e.ParamName, Is.EqualTo(parameterName));
                    throw;
                }
            });
        }

        [TestCaseSource(nameof(BookStoreItemWithIsniAndPublishedArgumentIsInvalidData))]
        public void BookStoreItem_WithIsniAndPublished_ArgumentIsInvalid_ThrowsArgumentException(string authorName, string isni, string title, string publisher, string isbn, DateTime published, string bookBinding, decimal price, string currency, int amount, string parameterName)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                try
                {
                    // Act
                    _ = new BookStoreItem(authorName: authorName, isni: isni, title: title, publisher: publisher, isbn: isbn, published: published, bookBinding: bookBinding, price: price, currency: currency, amount: amount);
                }
                catch (ArgumentException e)
                {
                    Assert.That(e.ParamName, Is.EqualTo(parameterName));
                    throw;
                }
            });
        }

        [Test]
        public void GetIsniUri_IsniIsNotSet_ThrowsInvalidOperationException()
        {
            // Arrange
            var bookStoreItem = new BookStoreItem(authorName: "Edgar Allan Poe", title: "Complete Stories and Poems of Edgar Allan Poe", publisher: "Doubleday", isbn: "0385074077");

            // Assert
            Assert.Throws<InvalidOperationException>(() => bookStoreItem.GetIsniUri());
        }

        [TestCase("Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077")]
        public void BookStoreItem_ArgumentsAreValid_ReturnsNewObject(string authorName, string title, string publisher, string isbn)
        {
            // Act
            var bookStoreItem = new BookStoreItem(authorName: authorName, title: title, publisher: publisher, isbn: isbn);

            // Assert
            Assert.That(bookStoreItem.AuthorName, Is.EqualTo(authorName));
            Assert.That(bookStoreItem.HasIsni, Is.EqualTo(false));
            Assert.That(bookStoreItem.Isni, Is.EqualTo(null));
            Assert.That(bookStoreItem.Title, Is.EqualTo(title));
            Assert.That(bookStoreItem.Publisher, Is.EqualTo(publisher));
            Assert.That(bookStoreItem.Isbn, Is.EqualTo(isbn));
            Assert.That(bookStoreItem.Published, Is.EqualTo(null));
            Assert.That(bookStoreItem.BookBinding, Is.EqualTo(string.Empty));
            Assert.That(bookStoreItem.Price, Is.EqualTo(0.0m));
            Assert.That(bookStoreItem.Currency, Is.EqualTo("USD"));
            Assert.That(bookStoreItem.Amount, Is.EqualTo(0));
        }

        [TestCase("Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077")]
        public void BookStoreItem_WithIsni_ArgumentsAreValid_ReturnsNewObject(string authorName, string isni, string title, string publisher, string isbn)
        {
            // Act
            var bookStoreItem = new BookStoreItem(authorName: authorName, isni: isni, title: title, publisher: publisher, isbn: isbn);

            // Assert
            Assert.That(bookStoreItem.AuthorName, Is.EqualTo(authorName));
            Assert.That(bookStoreItem.HasIsni, Is.EqualTo(true));
            Assert.That(bookStoreItem.Isni, Is.EqualTo(isni));
            Assert.That(bookStoreItem.Title, Is.EqualTo(title));
            Assert.That(bookStoreItem.Publisher, Is.EqualTo(publisher));
            Assert.That(bookStoreItem.Isbn, Is.EqualTo(isbn));
            Assert.That(bookStoreItem.Published, Is.EqualTo(null));
            Assert.That(bookStoreItem.BookBinding, Is.EqualTo(string.Empty));
            Assert.That(bookStoreItem.Price, Is.EqualTo(0.0m));
            Assert.That(bookStoreItem.Currency, Is.EqualTo("USD"));
            Assert.That(bookStoreItem.Amount, Is.EqualTo(0));
        }

        [TestCaseSource(nameof(BookStoreItemWithPublishedData))]
        public void BookStoreItem_WithPublished_ArgumentsAreValid_ReturnsNewObject(string authorName, string title, string publisher, string isbn, DateTime? published, string bookBinding, decimal price, string currency, int amount)
        {
            // Act
            var bookStoreItem = new BookStoreItem(authorName: authorName, title: title, publisher: publisher, isbn: isbn, published: published, bookBinding: bookBinding, price: price, currency: currency, amount: amount);

            // Assert
            Assert.That(bookStoreItem.AuthorName, Is.EqualTo(authorName));
            Assert.That(bookStoreItem.HasIsni, Is.EqualTo(false));
            Assert.That(bookStoreItem.Isni, Is.EqualTo(null));
            Assert.That(bookStoreItem.Title, Is.EqualTo(title));
            Assert.That(bookStoreItem.Publisher, Is.EqualTo(publisher));
            Assert.That(bookStoreItem.Isbn, Is.EqualTo(isbn));
            Assert.That(bookStoreItem.Published, Is.EqualTo(published));
            Assert.That(bookStoreItem.BookBinding, Is.EqualTo(bookBinding));
            Assert.That(bookStoreItem.Price, Is.EqualTo(price));
            Assert.That(bookStoreItem.Currency, Is.EqualTo(currency));
            Assert.That(bookStoreItem.Amount, Is.EqualTo(amount));
        }

        [TestCaseSource(nameof(BookStoreItemWithIsniAndPublishedData))]
        public void BookStoreItem_WithIsniAndPublished_ArgumentsAreValid_ReturnsNewObject(string authorName, string isni, string title, string publisher, string isbn, DateTime? published, string bookBinding, decimal price, string currency, int amount)
        {
            // Act
            var bookStoreItem = new BookStoreItem(authorName: authorName, isni: isni, title: title, publisher: publisher, isbn: isbn, published: published, bookBinding: bookBinding, price: price, currency: currency, amount: amount);

            // Assert
            Assert.That(bookStoreItem.AuthorName, Is.EqualTo(authorName));
            Assert.That(bookStoreItem.HasIsni, Is.EqualTo(true));
            Assert.That(bookStoreItem.Isni, Is.EqualTo(isni));
            Assert.That(bookStoreItem.Title, Is.EqualTo(title));
            Assert.That(bookStoreItem.Publisher, Is.EqualTo(publisher));
            Assert.That(bookStoreItem.Isbn, Is.EqualTo(isbn));
            Assert.That(bookStoreItem.Published, Is.EqualTo(published));
            Assert.That(bookStoreItem.BookBinding, Is.EqualTo(bookBinding));
            Assert.That(bookStoreItem.Price, Is.EqualTo(price));
            Assert.That(bookStoreItem.Currency, Is.EqualTo(currency));
            Assert.That(bookStoreItem.Amount, Is.EqualTo(amount));
        }

        [TestCase("Edgar Allan Poe", "0000000121354025", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", "https://isni.org/isni/0000000121354025")]
        public void GetIsniUri_IsniIsSet_ReturnsUri(string authorName, string isni, string title, string publisher, string isbn, string expectedResult)
        {
            // Arrange
            var bookStoreItem = new BookStoreItem(authorName: authorName, isni: isni, title: title, publisher: publisher, isbn: isbn);

            // Act
            var uri = bookStoreItem.GetIsniUri();

            // Assert
            Assert.That(uri, Is.Not.Null);
            Assert.That(uri.AbsoluteUri, Is.EqualTo(expectedResult));
        }

        [TestCase("Edgar Allan Poe", "Complete Stories and Poems of Edgar Allan Poe", "Doubleday", "0385074077", "https://isbnsearch.org/isbn/0385074077")]
        public void GetIsbnSearchUri_ReturnsUri(string authorName, string title, string publisher, string isbn, string expectedResult)
        {
            // Arrange
            var bookStoreItem = new BookStoreItem(authorName: authorName, title: title, publisher: publisher, isbn: isbn);

            // Act
            var uri = bookStoreItem.GetIsbnSearchUri();

            // Assert
            Assert.That(uri, Is.Not.Null);
            Assert.That(uri.AbsoluteUri, Is.EqualTo(expectedResult));
        }

        [TestCaseSource(nameof(ToStringData))]
        public void ToString_ReturnsString(string expectedResult, object[] constructorArguments)
        {
            // Arrange
            var bookStoreItem = (BookStoreItem)(Activator.CreateInstance(this.classType!, constructorArguments) ?? throw new InvalidOperationException());

            // Act
            var actualString = bookStoreItem.ToString();

            // Assert
            Assert.That(actualString, Is.EqualTo(expectedResult));
        }

        [SetUp]
        public void SetUp()
        {
            this.classType = typeof(BookStoreItem);
        }

        [Test]
        public void IsPublicClass()
        {
            this.AssertThatClassIsPublic(false);
        }

        [Test]
        public void InheritsObject()
        {
            this.AssertThatClassInheritsObject();
        }

        [Test]
        public void HasRequiredMembers()
        {
            Assert.AreEqual(0, this.classType!.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length);
            Assert.AreEqual(0, this.classType!.GetFields(BindingFlags.Instance | BindingFlags.Public).Length);
            Assert.AreEqual(11, this.classType!.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Length);

            Assert.AreEqual(0, this.classType!.GetConstructors(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length);
            Assert.AreEqual(4, this.classType!.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length);
            Assert.AreEqual(0, this.classType!.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Length);

            Assert.AreEqual(0, this.classType!.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length);
            Assert.AreEqual(11, this.classType!.GetProperties(BindingFlags.Instance | BindingFlags.Public).Length);
            Assert.AreEqual(0, this.classType!.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic).Length);

            Assert.AreEqual(0, this.classType!.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(4, this.classType!.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length);

            Assert.AreEqual(19, this.classType!.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Length);
            Assert.AreEqual(3, this.classType!.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length);

            Assert.AreEqual(0, this.classType!.GetEvents(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Length);
        }

        [TestCase("authorName", typeof(string), true)]
        [TestCase("isni", typeof(string), true)]
        [TestCase("hasIsni", typeof(bool), true)]
        [TestCase("price", typeof(decimal), false)]
        [TestCase("currency", typeof(string), false)]
        [TestCase("amount", typeof(int), false)]
        public void HasRequiredField(string fieldName, Type fieldType, bool isInitOnly)
        {
            this.AssertThatClassHasField(fieldName, fieldType, isInitOnly);
        }

        [TestCaseSource(nameof(ConstructorData))]
        public void HasPublicInstanceConstructor(Type[] parameterTypes)
        {
            this.AssertThatClassHasPublicConstructor(parameterTypes);
        }

        [TestCase("AuthorName", typeof(string), true, true, false, false)]
        [TestCase("Isni", typeof(string), true, true, false, false)]
        [TestCase("HasIsni", typeof(bool), true, true, false, false)]
        [TestCase("Title", typeof(string), true, true, true, false)]
        [TestCase("Publisher", typeof(string), true, true, true, false)]
        [TestCase("Isbn", typeof(string), true, true, true, false)]
        [TestCase("Published", typeof(DateTime?), true, true, true, true)]
        [TestCase("BookBinding", typeof(string), true, true, true, true)]
        [TestCase("Price", typeof(decimal), true, true, true, true)]
        [TestCase("Currency", typeof(string), true, true, true, true)]
        [TestCase("Amount", typeof(int), true, true, true, true)]
        public void HasProperty(string propertyName, Type propertyType, bool hasGet, bool isGetPublic, bool hasSet, bool isSetPublic)
        {
            this.AssertThatClassHasProperty(propertyName, propertyType, hasGet, isGetPublic, hasSet, isSetPublic);
        }

        [TestCase("GetIsniUri", false, true, false, typeof(Uri))]
        [TestCase("GetIsbnSearchUri", false, true, false, typeof(Uri))]
        [TestCase("ToString", false, true, true, typeof(string))]
        [TestCase("ValidateIsni", true, false, false, typeof(bool))]
        [TestCase("ValidateIsbn", true, false, false, typeof(bool))]
        [TestCase("ValidateIsbnChecksum", true, false, false, typeof(bool))]
        [TestCase("ThrowExceptionIfCurrencyIsNotValid", true, false, false, typeof(void))]
        public void HasMethod(string methodName, bool isStatic, bool isPublic, bool isVirtual, Type returnType)
        {
            this.AssertThatClassHasMethod(methodName, isStatic, isPublic, isVirtual, returnType);
        }

        [TestCaseSource(nameof(HasPrivateStaticMethodData))]
        public void HasPrivateStaticMethod(string methodName, object[] parameters, object expectedResult)
        {
            // Act
            var actualResult = this.InvokePrivateStaticMethod(methodName, parameters);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        private void AssertThatClassIsPublic(bool isSealed)
        {
            Assert.That(this.classType!.IsClass, Is.True);
            Assert.That(this.classType!.IsPublic, Is.True);
            Assert.That(this.classType!.IsAbstract, Is.False);
            Assert.That(this.classType!.IsSealed, isSealed ? Is.True : Is.False);
        }

        private void AssertThatClassHasField(string fieldName, Type fieldType, bool isInitOnly)
        {
            var fieldInfo = this.classType?.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);

            // Assert
            Assert.That(fieldInfo, Is.Not.Null);
            Assert.That(fieldInfo!.FieldType, Is.EqualTo(fieldType));
            Assert.That(fieldInfo!.IsInitOnly, isInitOnly ? Is.True : Is.False);
        }

        private void AssertThatClassInheritsObject()
        {
            Assert.That(this.classType!.BaseType, Is.EqualTo(typeof(object)));
        }

        private void AssertThatClassHasPublicConstructor(Type[] parameterTypes)
        {
            var constructorInfo = this.classType!.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, parameterTypes, null);
            Assert.That(constructorInfo, Is.Not.Null);
        }

        private PropertyInfo? AssertThatClassHasProperty(string propertyName, Type expectedPropertyType, bool hasGet, bool isGetPublic, bool hasSet, bool isSetPublic)
        {
            var propertyInfo = this.classType!.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.PropertyType, Is.EqualTo(expectedPropertyType));

            if (hasGet)
            {
                Assert.That(propertyInfo!.GetMethod!.IsPublic, isGetPublic ? Is.True : Is.False);
            }

            if (hasSet)
            {
                Assert.That(propertyInfo!.SetMethod!.IsPublic, isSetPublic ? Is.True : Is.False);
            }

            return propertyInfo;
        }

        private MethodInfo? AssertThatClassHasMethod(string methodName, bool isStatic, bool isPublic, bool isVirtual, Type returnType)
        {
            var methodInfo = this.classType!.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            Assert.That(methodInfo, Is.Not.Null);
            Assert.That(methodInfo!.IsStatic, isStatic ? Is.True : Is.False);
            Assert.That(methodInfo!.IsPublic, isPublic ? Is.True : Is.False);
            Assert.That(methodInfo!.IsVirtual, isVirtual ? Is.True : Is.False);
            Assert.That(methodInfo!.ReturnType, Is.EqualTo(returnType));

            return methodInfo;
        }

        private object? InvokePrivateStaticMethod(string methodName, object[] parameters)
        {
            var methodInfo = this.classType!.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly);
            Assert.That(methodInfo, Is.Not.Null);

            return methodInfo!.Invoke(null, parameters);
        }
    }
}
