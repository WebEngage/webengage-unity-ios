using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace WebEngageBridge
{
    public class WebEngage
    {
#if UNITY_IOS
        [DllImport("__Internal")]
        private static extern void login(string s);

        [DllImport("__Internal")]
        private static extern void logout();

        [DllImport("__Internal")]
        private static extern void trackEvent(string s);

        [DllImport("__Internal")]
        private static extern void trackEventWithAttributes(string s, string attributes);

        [DllImport("__Internal")]
        private static extern void setFirstName(string firstName);

        [DllImport("__Internal")]
        private static extern void setLastName(string lastName);

        [DllImport("__Internal")]
        private static extern void setEmail(string email);

        [DllImport("__Internal")]
        private static extern void setHashedEmail(string hashedEmail);

        [DllImport("__Internal")]
        private static extern void setPhoneNumber(string phoneNumber);

        [DllImport("__Internal")]
        private static extern void setHashedPhoneNumber(string hashedPhoneNumber);

        [DllImport("__Internal")]
        private static extern void setGender(string gender);

        [DllImport("__Internal")]
        private static extern void setBirthDate(string birthDate);

        [DllImport("__Internal")]
        private static extern void setCompany(string company);

        [DllImport("__Internal")]
        private static extern void setOptIn(string channel, bool optIn);

        [DllImport("__Internal")]
        private static extern void setLocation(double latitude, double longitude);

        [DllImport("__Internal")]
        private static extern void setUserAttributeString(string key, string value);

        [DllImport("__Internal")]
        private static extern void setUserAttributeBool(string key, bool value);

        [DllImport("__Internal")]
        private static extern void setUserAttributeInt(string key, int value);

        [DllImport("__Internal")]
        private static extern void setUserAttributeLong(string key, long value);

        [DllImport("__Internal")]
        private static extern void setUserAttributeFloat(string key, float value);

        [DllImport("__Internal")]
        private static extern void setUserAttributeDouble(string key, double value);

        [DllImport("__Internal")]
        private static extern void setUserAttributeDate(string key, string value);

        [DllImport("__Internal")]
        private static extern void setUserAttributes(string attributes);

        [DllImport("__Internal")]
        private static extern void deleteUserAttribute(string key);

        [DllImport("__Internal")]
        private static extern void deleteUserAttributes(string keys);

        [DllImport("__Internal")]
        private static extern void screenNavigated(string screen);

        [DllImport("__Internal")]
        private static extern void screenNavigatedWithData(string screen, string data);

        [DllImport("__Internal")]
        private static extern void setScreenData(string data);
#endif

        // Tracking events
        public static void TrackEvent(string eventName)
        {
#if UNITY_IOS
            trackEvent(eventName);
#endif
        }

        public static void TrackEvent(string eventName, Dictionary<string, object> attributes)
        {
#if UNITY_IOS
            var json = new JSONObject(attributes);
            trackEventWithAttributes(eventName, json.ToString());
#endif
        }

        // Tracking users
        public static void Login(string cuid)
        {
#if UNITY_IOS
            login(cuid);
#endif
        }

        public static void Logout()
        {
#if UNITY_IOS
            logout();
#endif
        }

        public static void SetFirstName(string firstName)
        {
#if UNITY_IOS
            setFirstName(firstName);
#endif
        }

        public static void SetLastName(string lastName)
        {
#if UNITY_IOS
            setLastName(lastName);
#endif
        }

        public static void SetEmail(string email)
        {
#if UNITY_IOS
            setEmail(email);
#endif
        }

        public static void SetHashedEmail(string hashedEmail)
        {
#if UNITY_IOS
            setHashedEmail(hashedEmail);
#endif
        }

        public static void SetPhoneNumber(string phoneNumber)
        {
#if UNITY_IOS
            setPhoneNumber(phoneNumber);
#endif
        }

        public static void SetHashedPhoneNumber(string hashedPhoneNumber)
        {
#if UNITY_IOS
            setHashedPhoneNumber(hashedPhoneNumber);
#endif
        }

        public static void SetCompany(string company)
        {
#if UNITY_IOS
            setCompany(company);
#endif
        }

        public static void SetBirthDate(string birthDate)
        {
#if UNITY_IOS
            setBirthDate(birthDate);
#endif
        }

        public static void SetLocation(double latitude, double longitude)
        {
#if UNITY_IOS
            setLocation(latitude, longitude);
#endif
        }

        public static void SetGender(string gender)
        {
            if (string.Compare(gender, "male", true) == 0)
            {
#if UNITY_IOS
                setGender("male");
#endif
            }
            else if (string.Compare(gender, "female", true) == 0)
            {
#if UNITY_IOS
                setGender("female");
#endif
            }
            else if (string.Compare(gender, "other", true) == 0)
            {
#if UNITY_IOS
                setGender("other");
#endif
            }
            else
            {
                Debug.Log("WebEngageBridge: Invalid gender: " + gender + ". Must be one of [male, female, other]");
            }
        }

        public static void SetOptIn(string channel, bool optIn)
        {
#if UNITY_IOS
            setOptIn(channel, optIn);
#endif
        }

        public static void SetUserAttribute(string key, object value)
        {
#if UNITY_IOS
            if (value == null)
            {
                Debug.LogError("User attribute is null for: " + key);
            }
            else if (value is string)
            {
                setUserAttributeString(key, (string) value);
            }
            else if (value is bool)
            {
                setUserAttributeBool(key, (bool) value);
            }
            else if (value is int)
            {
                setUserAttributeInt(key, (int) value);
            }
            else if (value is long)
            {
                setUserAttributeLong(key, (long) value);
            }
            else if (value is float)
            {
                setUserAttributeFloat(key, (float) value);
            }
            else if (value is double)
            {
                setUserAttributeDouble(key, (double) value);
            }
            else if (value is System.DateTime)
            {
                setUserAttributeDate(key, ((System.DateTime)value).ToString(WebEngageBridge.JSONObject.DATE_FORMAT));
            }
            else
            {
                Debug.LogError("Invalid datatype for user attribute: " + key + ", converting value to string");
                setUserAttributeString(key, value.ToString());
            }
#endif
        }

        public static void SetUserAttributes(Dictionary<string, object> attributes)
        {
#if UNITY_IOS
            var json = new JSONObject(attributes);
            string jsonString = json.ToString();
            setUserAttributes(jsonString);
#endif
        }

        public static void DeleteUserAttribute(string key)
        {
#if UNITY_IOS
            deleteUserAttribute(key);
#endif
        }

        public static void DeleteUserAttributes(List<string> keys)
        {
#if UNITY_IOS
            var json = new JSONObject(keys);
            string jsonString = json.ToString();
            deleteUserAttributes(jsonString);
#endif
        }

        // Tracking screens
        public static void ScreenNavigated(string screen)
        {
#if UNITY_IOS
            screenNavigated(screen);
#endif
        }

        public static void ScreenNavigated(string screen, Dictionary<string, object> data)
        {
#if UNITY_IOS
            var json = new JSONObject(data);
            string jsonString = json.ToString();
            screenNavigatedWithData(screen, jsonString);
#endif
        }

        public static void SetScreenData(Dictionary<string, object> data)
        {
#if UNITY_IOS
            var json = new JSONObject(data);
            string jsonString = json.ToString();
            setScreenData(jsonString);
#endif
        }
    }
}
