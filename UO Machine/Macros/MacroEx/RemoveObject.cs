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


namespace UOMachine.Macros
{
    public static partial class MacroEx
    {
        /// <summary>
        /// Send RemoveObject packet to client.
        /// </summary>
        /// <param name="client">Target client.</param>
        /// <param name="serial">Serial of item/mobile/multi.</param>
        public static void RemoveObject(int client, int serial)
        {
            byte[] packet = new byte[5];
            packet[0] = 0x1D;
            packet[1] = (byte)(serial >> 24);
            packet[2] = (byte)(serial >> 16);
            packet[3] = (byte)(serial >> 8);
            packet[4] = (byte)(serial);
            MacroEx.SendPacketToClient(client, packet);
        }
    }
}