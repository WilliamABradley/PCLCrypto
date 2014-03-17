//-----------------------------------------------------------------------
// <copyright file="KSec.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace PCLCrypto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MonoTouch;
    using MonoTouch.Foundation;
    using MonoTouch.ObjCRuntime;
    using MonoTouch.UIKit;
    using Validation;

    /// <summary>
    /// Constants for iOS Security APIs.
    /// </summary>
    internal static class KSec
    {
        /// <summary>
        /// Initializes static members of the <see cref="KSec"/> class.
        /// </summary>
        static KSec()
        {
            IntPtr handle = Dlfcn.dlopen(Constants.SecurityLibrary, 0);
            Assumes.False(handle == IntPtr.Zero);

            try
            {
                AttrApplicationTag = Dlfcn.GetStringConstant(handle, "kSecAttrApplicationTag");
                AttrKeyType = Dlfcn.GetStringConstant(handle, "kSecAttrKeyType");
                AttrKeySizeInBits = Dlfcn.GetStringConstant(handle, "kSecAttrKeySizeInBits");
                AttrKeyTypeRSA = Dlfcn.GetStringConstant(handle, "kSecAttrKeyTypeRSA");
                AttrIsPermanent = Dlfcn.GetStringConstant(handle, "kSecAttrIsPermanent");
                PublicKeyAttrs = Dlfcn.GetStringConstant(handle, "kSecPublicKeyAttrs");
                PrivateKeyAttrs = Dlfcn.GetStringConstant(handle, "kSecPrivateKeyAttrs");
                ClassKey = Dlfcn.GetStringConstant(handle, "kSecClassKey");
                Class = Dlfcn.GetStringConstant(handle, "kSecClass");
                ReturnData = Dlfcn.GetStringConstant(handle, "kSecReturnData");
            }
            finally
            {
                Dlfcn.dlclose(handle);
            }
        }

        /// <summary>
        /// Gets the kSecAttrKeyType value.
        /// </summary>
        public static NSString AttrKeyType { get; private set; }

        /// <summary>
        /// Gets the kSecAttrKeySizeInBits value.
        /// </summary>
        public static NSString AttrKeySizeInBits { get; private set; }

        /// <summary>
        /// Gets the kSecAttrKeyTypeRSA value.
        /// </summary>
        public static NSString AttrKeyTypeRSA { get; private set; }

        /// <summary>
        /// Gets the kSecAttrApplicationTag value.
        /// </summary>
        public static NSString AttrApplicationTag { get; private set; }

        /// <summary>
        /// Gets the kSecAttrIsPermanent value.
        /// </summary>
        public static NSString AttrIsPermanent { get; private set; }

        /// <summary>
        /// Gets the kSecPublicKeyAttrs value.
        /// </summary>
        public static NSString PublicKeyAttrs { get; private set; }

        /// <summary>
        /// Gets the kSecPrivateKeyAttrs value.
        /// </summary>
        public static NSString PrivateKeyAttrs { get; private set; }

        /// <summary>
        /// Gets the kSecClassKey value.
        /// </summary>
        public static NSString ClassKey { get; private set; }

        /// <summary>
        /// Gets the kSecClass value.
        /// </summary>
        public static NSString Class { get; private set; }

        /// <summary>
        /// Gets the kSecReturnData value.
        /// </summary>
        public static NSString ReturnData { get; private set; }
    }
}