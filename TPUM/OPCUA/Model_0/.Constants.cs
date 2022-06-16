/* ========================================================================
 * Copyright (c) 2005-2021 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace 
{
    #region DataType Identifiers
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypes
    {
        /// <summary>
        /// The identifier for the Book DataType.
        /// </summary>
        public const uint Book = 1;

        /// <summary>
        /// The identifier for the Person DataType.
        /// </summary>
        public const uint Person = 15;

        /// <summary>
        /// The identifier for the Lending DataType.
        /// </summary>
        public const uint Lending = 19;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the Book_tittle Variable.
        /// </summary>
        public const uint Book_tittle = 2;

        /// <summary>
        /// The identifier for the Book_isbn Variable.
        /// </summary>
        public const uint Book_isbn = 11;

        /// <summary>
        /// The identifier for the Book_author Variable.
        /// </summary>
        public const uint Book_author = 12;

        /// <summary>
        /// The identifier for the Book_isAvailable Variable.
        /// </summary>
        public const uint Book_isAvailable = 13;

        /// <summary>
        /// The identifier for the Book_id Variable.
        /// </summary>
        public const uint Book_id = 14;

        /// <summary>
        /// The identifier for the Person_id Variable.
        /// </summary>
        public const uint Person_id = 16;

        /// <summary>
        /// The identifier for the Person_firstName Variable.
        /// </summary>
        public const uint Person_firstName = 17;

        /// <summary>
        /// The identifier for the Person_surname Variable.
        /// </summary>
        public const uint Person_surname = 18;

        /// <summary>
        /// The identifier for the Lending_personID Variable.
        /// </summary>
        public const uint Lending_personID = 20;

        /// <summary>
        /// The identifier for the Lending_bookID Variable.
        /// </summary>
        public const uint Lending_bookID = 21;

        /// <summary>
        /// The identifier for the cas_BinarySchema Variable.
        /// </summary>
        public const uint cas_BinarySchema = 3;

        /// <summary>
        /// The identifier for the cas_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public const uint cas_BinarySchema_NamespaceUri = 5;

        /// <summary>
        /// The identifier for the cas_BinarySchema_Deprecated Variable.
        /// </summary>
        public const uint cas_BinarySchema_Deprecated = 6;

        /// <summary>
        /// The identifier for the cas_XmlSchema Variable.
        /// </summary>
        public const uint cas_XmlSchema = 7;

        /// <summary>
        /// The identifier for the cas_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public const uint cas_XmlSchema_NamespaceUri = 9;

        /// <summary>
        /// The identifier for the cas_XmlSchema_Deprecated Variable.
        /// </summary>
        public const uint cas_XmlSchema_Deprecated = 10;
    }
    #endregion

    #region DataType Node Identifiers
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypeIds
    {
        /// <summary>
        /// The identifier for the Book DataType.
        /// </summary>
        public static readonly ExpandedNodeId Book = new ExpandedNodeId(.DataTypes.Book, .Namespaces.cas);

        /// <summary>
        /// The identifier for the Person DataType.
        /// </summary>
        public static readonly ExpandedNodeId Person = new ExpandedNodeId(.DataTypes.Person, .Namespaces.cas);

        /// <summary>
        /// The identifier for the Lending DataType.
        /// </summary>
        public static readonly ExpandedNodeId Lending = new ExpandedNodeId(.DataTypes.Lending, .Namespaces.cas);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the Book_tittle Variable.
        /// </summary>
        public static readonly ExpandedNodeId Book_tittle = new ExpandedNodeId(.Variables.Book_tittle, .Namespaces.cas);

        /// <summary>
        /// The identifier for the Book_isbn Variable.
        /// </summary>
        public static readonly ExpandedNodeId Book_isbn = new ExpandedNodeId(.Variables.Book_isbn, .Namespaces.cas);

        /// <summary>
        /// The identifier for the Book_author Variable.
        /// </summary>
        public static readonly ExpandedNodeId Book_author = new ExpandedNodeId(.Variables.Book_author, .Namespaces.cas);

        /// <summary>
        /// The identifier for the Book_isAvailable Variable.
        /// </summary>
        public static readonly ExpandedNodeId Book_isAvailable = new ExpandedNodeId(.Variables.Book_isAvailable, .Namespaces.cas);

        /// <summary>
        /// The identifier for the Book_id Variable.
        /// </summary>
        public static readonly ExpandedNodeId Book_id = new ExpandedNodeId(.Variables.Book_id, .Namespaces.cas);

        /// <summary>
        /// The identifier for the Person_id Variable.
        /// </summary>
        public static readonly ExpandedNodeId Person_id = new ExpandedNodeId(.Variables.Person_id, .Namespaces.cas);

        /// <summary>
        /// The identifier for the Person_firstName Variable.
        /// </summary>
        public static readonly ExpandedNodeId Person_firstName = new ExpandedNodeId(.Variables.Person_firstName, .Namespaces.cas);

        /// <summary>
        /// The identifier for the Person_surname Variable.
        /// </summary>
        public static readonly ExpandedNodeId Person_surname = new ExpandedNodeId(.Variables.Person_surname, .Namespaces.cas);

        /// <summary>
        /// The identifier for the Lending_personID Variable.
        /// </summary>
        public static readonly ExpandedNodeId Lending_personID = new ExpandedNodeId(.Variables.Lending_personID, .Namespaces.cas);

        /// <summary>
        /// The identifier for the Lending_bookID Variable.
        /// </summary>
        public static readonly ExpandedNodeId Lending_bookID = new ExpandedNodeId(.Variables.Lending_bookID, .Namespaces.cas);

        /// <summary>
        /// The identifier for the cas_BinarySchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId cas_BinarySchema = new ExpandedNodeId(.Variables.cas_BinarySchema, .Namespaces.cas);

        /// <summary>
        /// The identifier for the cas_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId cas_BinarySchema_NamespaceUri = new ExpandedNodeId(.Variables.cas_BinarySchema_NamespaceUri, .Namespaces.cas);

        /// <summary>
        /// The identifier for the cas_BinarySchema_Deprecated Variable.
        /// </summary>
        public static readonly ExpandedNodeId cas_BinarySchema_Deprecated = new ExpandedNodeId(.Variables.cas_BinarySchema_Deprecated, .Namespaces.cas);

        /// <summary>
        /// The identifier for the cas_XmlSchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId cas_XmlSchema = new ExpandedNodeId(.Variables.cas_XmlSchema, .Namespaces.cas);

        /// <summary>
        /// The identifier for the cas_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId cas_XmlSchema_NamespaceUri = new ExpandedNodeId(.Variables.cas_XmlSchema_NamespaceUri, .Namespaces.cas);

        /// <summary>
        /// The identifier for the cas_XmlSchema_Deprecated Variable.
        /// </summary>
        public static readonly ExpandedNodeId cas_XmlSchema_Deprecated = new ExpandedNodeId(.Variables.cas_XmlSchema_Deprecated, .Namespaces.cas);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the author component.
        /// </summary>
        public const string author = "author";

        /// <summary>
        /// The BrowseName for the Book component.
        /// </summary>
        public const string Book = "Book";

        /// <summary>
        /// The BrowseName for the bookID component.
        /// </summary>
        public const string bookID = "bookID";

        /// <summary>
        /// The BrowseName for the cas_BinarySchema component.
        /// </summary>
        public const string cas_BinarySchema = "";

        /// <summary>
        /// The BrowseName for the cas_XmlSchema component.
        /// </summary>
        public const string cas_XmlSchema = "";

        /// <summary>
        /// The BrowseName for the firstName component.
        /// </summary>
        public const string firstName = "firstName";

        /// <summary>
        /// The BrowseName for the id component.
        /// </summary>
        public const string id = "id";

        /// <summary>
        /// The BrowseName for the isAvailable component.
        /// </summary>
        public const string isAvailable = "isAvailable";

        /// <summary>
        /// The BrowseName for the isbn component.
        /// </summary>
        public const string isbn = "isbn";

        /// <summary>
        /// The BrowseName for the Lending component.
        /// </summary>
        public const string Lending = "Lending";

        /// <summary>
        /// The BrowseName for the Person component.
        /// </summary>
        public const string Person = "Person";

        /// <summary>
        /// The BrowseName for the personID component.
        /// </summary>
        public const string personID = "personID";

        /// <summary>
        /// The BrowseName for the surname component.
        /// </summary>
        public const string surname = "surname";

        /// <summary>
        /// The BrowseName for the tittle component.
        /// </summary>
        public const string tittle = "tittle";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the cas namespace (.NET code namespace is '').
        /// </summary>
        public const string cas = "http://cas.eu/UA/CommServer/";

        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";
    }
    #endregion
}