﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Zero.Edit
{
    /// <summary>
    /// Zero框架编辑器菜单
    /// </summary>
    public class EditorMenu : AEditorWin
    {
        [MenuItem("Zero/Setting", false, 0)]
        public static void Setting()
        {
            SettingEditorWin.Open();
        }

        [MenuItem("Zero/AssetBundle", false, 100)]
        public static void AssetBundle()
        {
            ABEditorWin.Open();
        }

        [MenuItem("Zero/DLL", false, 101)]
        public static void ILRuntimeDLL()
        {
            DllEditorWin.Open();
        }

        [MenuItem("Zero/Res", false, 200)]
        public static void Res()
        {
            ResEditorWin.Open();                                 
        }

        /// <summary>
        /// 当前发布平台
        /// </summary>
        public static BuildTarget CurrentPlatform
        {
            get
            {
                BuildTarget platform;
#if UNITY_STANDALONE
                platform = BuildTarget.StandaloneWindows;
#elif UNITY_IPHONE
        platform = BuildTarget.iOS;
#elif UNITY_ANDROID
        platform = BuildTarget.Android;
#endif
                return platform;
            }
        }

        /// <summary>
        /// 编辑器生成的配置文件保存目录
        /// </summary>
        /// <returns></returns>
        public static string GetConfigDir()
        {            
            DirectoryInfo temp = Directory.GetParent(Application.dataPath);
            string dir = Path.Combine(temp.FullName, "EditorConfig");
            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }

        /// <summary>
        /// 打开目录
        /// </summary>
        /// <param name="path"></param>
        public static void OpenDirectory(string path)
        {                           
            if (string.IsNullOrEmpty(path)) return;

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                path = path.Replace("/", "\\");
                if (!Directory.Exists(path))
                {
                    Debug.LogError("No Directory: " + path);
                    return;
                }

                System.Diagnostics.Process.Start("explorer.exe", path);
            }
        }

        public static string PlatformDirName
        {
            get {
                string name;

#if UNITY_STANDALONE
                name = "pc/";     
#elif UNITY_IPHONE
        name = "ios/";
#elif UNITY_ANDROID
                name = "android/";
#endif
                return name;
            }
        }


    }
}