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

namespace cas
{
    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the Book ObjectType.
        /// </summary>
        public const uint Book = 1;

        /// <summary>
        /// The identifier for the Person ObjectType.
        /// </summary>
        public const uint Person = 15;

        /// <summary>
        /// The identifier for the Lending ObjectType.
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
        /// The identifier for the Book_title Variable.
        /// </summary>
        public const uint Book_title = 22;

        /// <summary>
        /// The identifier for the Book_author Variable.
        /// </summary>
        public const uint Book_author = 12;

        /// <summary>
        /// The identifier for the Book_isbn Variable.
        /// </summary>
        public const uint Book_isbn = 11;

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
        /// The identifier for the Lending_bookID Variable.
        /// </summary>
        public const uint Lending_bookID = 21;

        /// <summary>
        /// The identifier for the Lending_personID Variable.
        /// </summary>
        public const uint Lending_personID = 20;
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the Book ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId Book = new ExpandedNodeId(cas.ObjectTypes.Book, cas.Namespaces.cas);

        /// <summary>
        /// The identifier for the Person ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId Person = new ExpandedNodeId(cas.ObjectTypes.Person, cas.Namespaces.cas);

        /// <summary>
        /// The identifier for the Lending ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId Lending = new ExpandedNodeId(cas.ObjectTypes.Lending, cas.Namespaces.cas);
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
        /// The identifier for the Book_title Variable.
        /// </summary>
        public static readonly ExpandedNodeId Book_title = new ExpandedNodeId(cas.Variables.Book_title, cas.Namespaces.cas);

        /// <summary>
        /// The identifier for the Book_author Variable.
        /// </summary>
        public static readonly ExpandedNodeId Book_author = new ExpandedNodeId(cas.Variables.Book_author, cas.Namespaces.cas);

        /// <summary>
        /// The identifier for the Book_isbn Variable.
        /// </summary>
        public static readonly ExpandedNodeId Book_isbn = new ExpandedNodeId(cas.Variables.Book_isbn, cas.Namespaces.cas);

        /// <summary>
        /// The identifier for the Book_id Variable.
        /// </summary>
        public static readonly ExpandedNodeId Book_id = new ExpandedNodeId(cas.Variables.Book_id, cas.Namespaces.cas);

        /// <summary>
        /// The identifier for the Person_id Variable.
        /// </summary>
        public static readonly ExpandedNodeId Person_id = new ExpandedNodeId(cas.Variables.Person_id, cas.Namespaces.cas);

        /// <summary>
        /// The identifier for the Person_firstName Variable.
        /// </summary>
        public static readonly ExpandedNodeId Person_firstName = new ExpandedNodeId(cas.Variables.Person_firstName, cas.Namespaces.cas);

        /// <summary>
        /// The identifier for the Person_surname Variable.
        /// </summary>
        public static readonly ExpandedNodeId Person_surname = new ExpandedNodeId(cas.Variables.Person_surname, cas.Namespaces.cas);

        /// <summary>
        /// The identifier for the Lending_bookID Variable.
        /// </summary>
        public static readonly ExpandedNodeId Lending_bookID = new ExpandedNodeId(cas.Variables.Lending_bookID, cas.Namespaces.cas);

        /// <summary>
        /// The identifier for the Lending_personID Variable.
        /// </summary>
        public static readonly ExpandedNodeId Lending_personID = new ExpandedNodeId(cas.Variables.Lending_personID, cas.Namespaces.cas);
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
        /// The BrowseName for the firstName component.
        /// </summary>
        public const string firstName = "firstName";

        /// <summary>
        /// The BrowseName for the id component.
        /// </summary>
        public const string id = "id";

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
        /// The BrowseName for the title component.
        /// </summary>
        public const string title = "title";
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
        /// The URI for the cas namespace (.NET code namespace is 'cas').
        /// </summary>
        public const string cas = "http://cas.eu/UA/CommServer/";

        /// <summary>
        /// The URI for the casXsd namespace (.NET code namespace is 'cas').
        /// </summary>
        public const string casXsd = "cas";

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