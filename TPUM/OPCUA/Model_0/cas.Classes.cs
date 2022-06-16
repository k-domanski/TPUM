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
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace cas
{
    #region BookState Class
    #if (!OPCUA_EXCLUDE_BookState)
    /// <summary>
    /// Stores an instance of the Book ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class BookState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public BookState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(cas.ObjectTypes.Book, cas.Namespaces.cas, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAABwAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIv/////wRggAIBAAAAAQAMAAAAQm9va0lu" +
           "c3RhbmNlAQEBAAEBAQABAAAA/////wQAAAAVYIkKAgAAAAEABQAAAHRpdGxlAQEWAAAvAD8WAAAAAAz/" +
           "////AQH/////AAAAABVgiQoCAAAAAQAGAAAAYXV0aG9yAQEMAAAvAD8MAAAAAAz/////AQH/////AAAA" +
           "ABVgiQoCAAAAAQAEAAAAaXNibgEBCwAALwA/CwAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAEAAgAA" +
           "AGlkAQEOAAAvAD8OAAAAAA7/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState<string> title
        {
            get
            {
                return m_title;
            }

            set
            {
                if (!Object.ReferenceEquals(m_title, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_title = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<string> author
        {
            get
            {
                return m_author;
            }

            set
            {
                if (!Object.ReferenceEquals(m_author, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_author = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<string> isbn
        {
            get
            {
                return m_isbn;
            }

            set
            {
                if (!Object.ReferenceEquals(m_isbn, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_isbn = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<Guid> id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_title != null)
            {
                children.Add(m_title);
            }

            if (m_author != null)
            {
                children.Add(m_author);
            }

            if (m_isbn != null)
            {
                children.Add(m_isbn);
            }

            if (m_id != null)
            {
                children.Add(m_id);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case cas.BrowseNames.title:
                {
                    if (createOrReplace)
                    {
                        if (title == null)
                        {
                            if (replacement == null)
                            {
                                title = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                title = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = title;
                    break;
                }

                case cas.BrowseNames.author:
                {
                    if (createOrReplace)
                    {
                        if (author == null)
                        {
                            if (replacement == null)
                            {
                                author = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                author = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = author;
                    break;
                }

                case cas.BrowseNames.isbn:
                {
                    if (createOrReplace)
                    {
                        if (isbn == null)
                        {
                            if (replacement == null)
                            {
                                isbn = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                isbn = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = isbn;
                    break;
                }

                case cas.BrowseNames.id:
                {
                    if (createOrReplace)
                    {
                        if (id == null)
                        {
                            if (replacement == null)
                            {
                                id = new BaseDataVariableState<Guid>(this);
                            }
                            else
                            {
                                id = (BaseDataVariableState<Guid>)replacement;
                            }
                        }
                    }

                    instance = id;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState<string> m_title;
        private BaseDataVariableState<string> m_author;
        private BaseDataVariableState<string> m_isbn;
        private BaseDataVariableState<Guid> m_id;
        #endregion
    }
    #endif
    #endregion

    #region PersonState Class
    #if (!OPCUA_EXCLUDE_PersonState)
    /// <summary>
    /// Stores an instance of the Person ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class PersonState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public PersonState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(cas.ObjectTypes.Person, cas.Namespaces.cas, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAABwAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIv/////wRggAIBAAAAAQAOAAAAUGVyc29u" +
           "SW5zdGFuY2UBAQ8AAQEPAA8AAAD/////AwAAABVgiQoCAAAAAQACAAAAaWQBARAAAC8APxAAAAAADv//" +
           "//8BAf////8AAAAAFWCJCgIAAAABAAkAAABmaXJzdE5hbWUBAREAAC8APxEAAAAADP////8BAf////8A" +
           "AAAAFWCJCgIAAAABAAcAAABzdXJuYW1lAQESAAAvAD8SAAAAAAz/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState<Guid> id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<string> firstName
        {
            get
            {
                return m_firstName;
            }

            set
            {
                if (!Object.ReferenceEquals(m_firstName, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_firstName = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<string> surname
        {
            get
            {
                return m_surname;
            }

            set
            {
                if (!Object.ReferenceEquals(m_surname, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_surname = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_id != null)
            {
                children.Add(m_id);
            }

            if (m_firstName != null)
            {
                children.Add(m_firstName);
            }

            if (m_surname != null)
            {
                children.Add(m_surname);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case cas.BrowseNames.id:
                {
                    if (createOrReplace)
                    {
                        if (id == null)
                        {
                            if (replacement == null)
                            {
                                id = new BaseDataVariableState<Guid>(this);
                            }
                            else
                            {
                                id = (BaseDataVariableState<Guid>)replacement;
                            }
                        }
                    }

                    instance = id;
                    break;
                }

                case cas.BrowseNames.firstName:
                {
                    if (createOrReplace)
                    {
                        if (firstName == null)
                        {
                            if (replacement == null)
                            {
                                firstName = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                firstName = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = firstName;
                    break;
                }

                case cas.BrowseNames.surname:
                {
                    if (createOrReplace)
                    {
                        if (surname == null)
                        {
                            if (replacement == null)
                            {
                                surname = new BaseDataVariableState<string>(this);
                            }
                            else
                            {
                                surname = (BaseDataVariableState<string>)replacement;
                            }
                        }
                    }

                    instance = surname;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState<Guid> m_id;
        private BaseDataVariableState<string> m_firstName;
        private BaseDataVariableState<string> m_surname;
        #endregion
    }
    #endif
    #endregion

    #region LendingState Class
    #if (!OPCUA_EXCLUDE_LendingState)
    /// <summary>
    /// Stores an instance of the Lending ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class LendingState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public LendingState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(cas.ObjectTypes.Lending, cas.Namespaces.cas, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAABwAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIv/////wRggAIBAAAAAQAPAAAATGVuZGlu" +
           "Z0luc3RhbmNlAQETAAEBEwATAAAA/////wIAAAAVYIkKAgAAAAEABgAAAGJvb2tJRAEBFQAALwA/FQAA" +
           "AAAO/////wEB/////wAAAAAVYIkKAgAAAAEACAAAAHBlcnNvbklEAQEUAAAvAD8UAAAAAA7/////AQH/" +
           "////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public BaseDataVariableState<Guid> bookID
        {
            get
            {
                return m_bookID;
            }

            set
            {
                if (!Object.ReferenceEquals(m_bookID, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_bookID = value;
            }
        }

        /// <remarks />
        public BaseDataVariableState<Guid> personID
        {
            get
            {
                return m_personID;
            }

            set
            {
                if (!Object.ReferenceEquals(m_personID, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_personID = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_bookID != null)
            {
                children.Add(m_bookID);
            }

            if (m_personID != null)
            {
                children.Add(m_personID);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case cas.BrowseNames.bookID:
                {
                    if (createOrReplace)
                    {
                        if (bookID == null)
                        {
                            if (replacement == null)
                            {
                                bookID = new BaseDataVariableState<Guid>(this);
                            }
                            else
                            {
                                bookID = (BaseDataVariableState<Guid>)replacement;
                            }
                        }
                    }

                    instance = bookID;
                    break;
                }

                case cas.BrowseNames.personID:
                {
                    if (createOrReplace)
                    {
                        if (personID == null)
                        {
                            if (replacement == null)
                            {
                                personID = new BaseDataVariableState<Guid>(this);
                            }
                            else
                            {
                                personID = (BaseDataVariableState<Guid>)replacement;
                            }
                        }
                    }

                    instance = personID;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private BaseDataVariableState<Guid> m_bookID;
        private BaseDataVariableState<Guid> m_personID;
        #endregion
    }
    #endif
    #endregion
}