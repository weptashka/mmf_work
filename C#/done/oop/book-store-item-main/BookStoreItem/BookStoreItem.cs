using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Text;
//АРТЁМ

namespace BookStoreItem
{
    /// <summary>
    /// Represents the an item in a book store.
    /// </summary>
    public class BookStoreItem
    {
        private readonly string authorName;
        private readonly string? isni;
        private readonly bool hasIsni;
        private decimal price;
        private string currency = "USD";
        private int amount;
        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        public BookStoreItem(string authorName, string title, string publisher, string isbn)
        {
            if (authorName.Length == 0 || authorName.Replace(" ", string.Empty, StringComparison.Ordinal).Length == 0)
            {
                throw new ArgumentException("authorName or title or publisher is not valid", nameof(authorName));
            }
            else if (title.Length == 0 || title.Replace(" ", string.Empty, StringComparison.Ordinal).Length == 0)
            {
                throw new ArgumentException("authorName or title or publisher is not valid", nameof(title));
            }
            else if (publisher.Length == 0 || publisher.Replace(" ", string.Empty, StringComparison.Ordinal).Length == 0)
            {
                throw new ArgumentException("authorName or title or publisher is not valid", nameof(publisher));
            }
            else
            {
                this.authorName = authorName;
                this.Title = title;
                this.Publisher = publisher;
            }

            if (ValidateIsbn(isbn))
            {
                this.Isbn = isbn;
            }
            else
            {
                throw new ArgumentException("isbn is not valid", nameof(isbn));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isni">A book author's ISNI.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        public BookStoreItem(string authorName, string isni, string title, string publisher, string isbn)
            : this(authorName, title, publisher, isbn)
        {
            if (ValidateIsni(isni))
            {
                this.isni = isni;
                this.hasIsni = true;
            }
            else
            {
                throw new ArgumentException("isni is not valid", nameof(isni));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        /// <param name="published">A book publishing date.</param>
        /// <param name="bookBinding">A book binding type.</param>
        /// <param name="price">An amount of money that a book costs.</param>
        /// <param name="currency">A price currency.</param>
        /// <param name="amount">An amount of books in the store's stock.</param>
        public BookStoreItem(string authorName, string title, string publisher, string isbn, DateTime? published, string bookBinding, decimal price, string currency, int amount)
            : this(authorName, title, publisher, isbn)
        {
            this.Published = published;
            this.BookBinding = bookBinding;
            this.price = price;
            ThrowExceptionIfCurrencyIsNotValid(currency);
            this.currency = currency;

            this.amount = amount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isni">A book author's ISNI.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        /// <param name="published">A book publishing date.</param>
        /// <param name="bookBinding">A book binding type.</param>
        /// <param name="price">An amount of money that a book costs.</param>
        /// <param name="currency">A price currency.</param>
        /// <param name="amount">An amount of books in the store's stock.</param>
        public BookStoreItem(string authorName, string isni, string title, string publisher, string isbn, DateTime? published, string bookBinding, decimal price, string currency, int amount)
            : this(authorName, title, publisher, isbn, published, bookBinding, price, currency, amount)
        {
            if (ValidateIsni(isni))
            {
                this.isni = isni;
                this.hasIsni = true;
            }
            else
            {
                throw new ArgumentException("isni is not valid", nameof(isni));
            }
        }

        /// <summary>
        /// Gets a book author's name.
        /// </summary>
        public string AuthorName
        {
            get { return this.authorName; }
        }

        /// <summary>
        /// Gets an International Standard Name Identifier (ISNI) that uniquely identifies a book author.
        /// </summary>
        public string? Isni
        {
            get => this.isni;
        }

        /// <summary>
        /// Gets a value indicating whether an author has an International Standard Name Identifier (ISNI).
        /// </summary>
        public bool HasIsni
        {
            get => this.hasIsni;
        }

        /// <summary>
        /// Gets a book title.
        /// </summary>
        public string Title
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a book publisher.
        /// </summary>
        public string Publisher
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a book International Standard Book Number (ISBN).
        /// </summary>
        public string Isbn
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a book publishing date.
        /// </summary>
        public DateTime? Published
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a book binding type.
        /// </summary>
        public string BookBinding
        {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// Gets or sets an amount of money that a book costs.
        /// </summary>
        public decimal Price
        {
            get => this.price;

            set
            {
                if (value >= 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Error: price is lower zero");
                }
            }
        }

        /// <summary>
        /// Gets or sets a price currency.
        /// </summary>
        public string Currency
        {
            get => this.currency;
            set
            {
                ThrowExceptionIfCurrencyIsNotValid(value);
                this.currency = value;

                //тут надо написать else и использовать функцию ThrowExceptionIfCurrencyIsNotValid
            }
        }

        /// <summary>
        /// Gets or sets an amount of books in the store's stock.
        /// </summary>
        public int Amount
        {
            get => this.amount;
            set
            {
                if (value >= 0)
                {
                    this.amount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Error: amount is lower zero");
                }
            }
        }

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            const string delimiter = ", ";
            var res = new StringBuilder();
            res.Append(this.Title).Append(delimiter).Append(this.authorName).Append(delimiter);

            res.Append(this.isni ?? "ISNI IS NOT SET").Append(delimiter);

            string priceValue = $"{this.Price:N2}";
            if (priceValue.Contains(','))
            {
                res.Append("\"").Append(priceValue).Append(" ").Append(currency).Append("\"");
            }
            else
            {
                res.Append(priceValue).Append(" ").Append(currency);
            }

            res.Append(delimiter).Append(Amount);

            return res.ToString();
        }

        /// <summary>
        /// Gets a <see cref="Uri"/> to the contributor's page at the isni.org website.
        /// </summary>
        /// <returns>A <see cref="Uri"/> to the contributor's page at the isni.org website.</returns>
        public Uri GetIsniUri()
        {
            if (this.isni != null)
            {
                return new Uri($"https://isni.org/isni/{this.isni}");
            }
            else
            {
                throw new InvalidOperationException("isni url is null");
            }
        }

        /// <summary>
        /// Gets an <see cref="Uri"/> to the publication page on the isbnsearch.org website.
        /// </summary>
        /// <returns>an <see cref="Uri"/> to the publication page on the isbnsearch.org website.</returns>
        public Uri GetIsbnSearchUri()
        {
            if (this.Isbn != null)
            {
                return new Uri($"https://isbnsearch.org/isbn/{this.Isbn}");
            }
            else
            {
                throw new InvalidOperationException("isbn url is null");
            }
        }

        private static void ThrowExceptionIfCurrencyIsNotValid(string currency)
        {
            bool isCurrency = true;
            foreach (char c in currency)
            {
                if (!char.IsLetter(c))
                {
                    isCurrency = false;
                }
            }

            if (!(isCurrency && currency.Length == 3))
            {
                throw new ArgumentException("Its not a currency", nameof(currency));
            }
        }

        private static bool ValidateIsni(string isni)
        {
            bool flag = true;
            if (isni.Length != 16)
            {
                return false;
            }

            foreach (char c in isni)
            {
                if (!(char.IsDigit(c) || c == 'X'))
                {
                    flag = false;
                }
            }

            if (flag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool ValidateIsbn(string isbn)
        {
            bool flag = true;
            if (isbn.Length != 10)
            {
                return false;
            }

            foreach (char c in isbn)
            {
                if (!(char.IsDigit(c) || c == 'X'))
                {
                    flag = false;
                }
            }

            if (flag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool ValidateIsbnChecksum(string isbn)
        {
            int[] isbnNums = new int[10];
            for (int i = 0; i < 10; i++)
            {
            switch (isbn[i])
                {
                    case '1':
                        isbnNums[i] = 1;
                        break;
                    case '2':
                        isbnNums[i] = 2;
                        break;
                    case '3':
                        isbnNums[i] = 3;
                        break;
                    case '4':
                        isbnNums[i] = 4;
                        break;
                    case '5':
                        isbnNums[i] = 5;
                        break;
                    case '6':
                        isbnNums[i] = 6;
                        break;
                    case '7':
                        isbnNums[i] = 7;
                        break;
                    case '8':
                        isbnNums[i] = 8;
                        break;
                    case '9':
                        isbnNums[i] = 9;
                        break;
                    case 'X':
                        isbnNums[i] = 10;
                        break;
                }
            }

            int checkSum = 0;
            for (int i = 1; i <= 10; i++)
            {
                checkSum += (11 - i) * isbnNums[i - 1];
            }

            if (checkSum % 11 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
