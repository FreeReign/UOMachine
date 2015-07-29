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


namespace UOMachine.Data
{
    public sealed class ServerInfo
    {
        private string myName;
        public string Name
        {
            get { return myName; }
            internal set { myName = value; }
        }

        private byte myPercentFull;
        public byte PercentFull
        {
            get { return myPercentFull; }
            internal set { myPercentFull = value; }
        }

        private byte myTimezone;
        public byte Timezone
        {
            get { return myTimezone; }
            internal set { myTimezone = value; }
        }

        private uint myIP;
        public uint IP
        {
            get { return myIP; }
            internal set { myIP = value; }
        }
    }
}