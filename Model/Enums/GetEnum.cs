﻿using Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enums
{
    public class GetEnum
    {
        public static TrangThaiDonHangEnum GetByCode(int code)
        {
            Array allTrangThai = Enum.GetValues(typeof(TrangThaiDonHangEnum));

            foreach (TrangThaiDonHangEnum trangThai in allTrangThai)
            {
                int c = GetCode(trangThai);
                if (c == code)
                {
                    return trangThai;
                }
            }
            throw new ArgumentOutOfRangeException(nameof(code), @"Value not found in enum type");
        }
        public static string GetText(TrangThaiDonHangEnum trangThaiDonHang)
        {
            TrangThaiAttribute trangThaiAttr = GetAttr(trangThaiDonHang);
            return trangThaiAttr.Text;
        }

        public static int GetCode(TrangThaiDonHangEnum trangThaiDonHang)
        {
            TrangThaiAttribute trangThaiAttr = GetAttr(trangThaiDonHang);
            return trangThaiAttr.Code;
        }
        private static TrangThaiAttribute GetAttr(TrangThaiDonHangEnum trangThaiDonHang)
        {
            MemberInfo memberInfo = GetMemberInfo(trangThaiDonHang);
            return (TrangThaiAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(TrangThaiAttribute));
        }

        private static MemberInfo GetMemberInfo(TrangThaiDonHangEnum trangThaiDonHang)
        {
            MemberInfo memberInfo
                = typeof(TrangThaiDonHangEnum).GetField(Enum.GetName(typeof(TrangThaiDonHangEnum), trangThaiDonHang));

            return memberInfo;
        }

    }

    public class GetLichHenEnum
    {
        public static TrangThaiLichHenEnum GetByCode(int code)
        {
            Array allTrangThai = Enum.GetValues(typeof(TrangThaiLichHenEnum));

            foreach (TrangThaiLichHenEnum trangThai in allTrangThai)
            {
                int c = GetCode(trangThai);
                if (c == code)
                {
                    return trangThai;
                }
            }
            throw new ArgumentOutOfRangeException(nameof(code), @"Value not found in enum type");
        }
        public static string GetText(TrangThaiLichHenEnum trangThaiLichHen)
        {
            TrangThaiAttribute trangThaiAttr = GetAttr(trangThaiLichHen);
            return trangThaiAttr.Text;
        }

        public static int GetCode(TrangThaiLichHenEnum trangThaiLichHen)
        {
            TrangThaiAttribute trangThaiAttr = GetAttr(trangThaiLichHen);
            return trangThaiAttr.Code;
        }
        private static TrangThaiAttribute GetAttr(TrangThaiLichHenEnum trangThaiLichHen)
        {
            MemberInfo memberInfo = GetMemberInfo(trangThaiLichHen);
            return (TrangThaiAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(TrangThaiAttribute));
        }

        private static MemberInfo GetMemberInfo(TrangThaiLichHenEnum trangThaiLichHen)
        {
            MemberInfo memberInfo
                = typeof(TrangThaiLichHenEnum).GetField(Enum.GetName(typeof(TrangThaiLichHenEnum), trangThaiLichHen));

            return memberInfo;
        }

    }
}
