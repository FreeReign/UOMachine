﻿/* Copyright (C) 2009 Matthew Geyer
 * 
 * This file is part of UO Machine.
 * 
 * UO Machine is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * UO Machine is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with UO Machine.  If not, see <http://www.gnu.org/licenses/>. */

using System;
using UOMachine;
using System.Windows.Forms;

namespace UOMachine.Macros
{
    public static partial class Macro
    {
        /// <summary>
        /// Add keyboard macro to specified client.
        /// </summary>
        /// <param name="client">Client index.</param>
        /// <param name="keys">Keys associated with the macro.</param>
        /// <param name="callback">A delegate to be called whenever the specified key combination is pressed.</param>
        /// <returns>True on success.</returns>
        public static bool AddKeyboardMacro(int client, Keys[] keys, KeyPressCallback callback)
        {
            ClientInfo ci;
            if (ClientInfoCollection.GetClient(client, out ci))
                return ci.HotKeyList.AddKeys(keys, callback);
            return false;
        }
    }
}