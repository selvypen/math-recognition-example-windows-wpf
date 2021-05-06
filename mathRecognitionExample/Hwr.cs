/*!
 *  @brief Math Handwriting APIs
 *  @date 2020/01/17
 *  @file Hwr.cs
 *  @author samu.s.ko
 *
 *  Copyright 2020. SELVAS AI Inc. All Rights Reserved.
 */

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Selvasai
{
    class Hwr
    {
        // Error Code ----------------------------------------------------------
        /// <summary>
        /// 성공
        /// </summary>
        public const int ERR_SUCCESS = 0;
        /// <summary>
        /// 인식결과가 없음
        /// </summary>
        public const int ERR_NORESULT = 1;
        /// <summary>
        /// Null Pointer를 참조함
        /// </summary>
        public const int ERR_NULL_POINTER = 2;
        /// <summary>
        /// memory access 범위를 벗어남 fatal error
        /// </summary>
        public const int ERR_OUTOFMEMORY = 3;
        /// <summary>
        /// value or size 범위를 벗어남 exception
        /// </summary>
        public const int ERR_OUTOFRANGE = 4;
        /// <summary>
        /// 입력된 데이터가 없음
        /// </summary>
        public const int ERR_EMPTY_INK = 5;
        /// <summary>
        /// 입력된 인자가 잘못됨
        /// </summary>
        public const int ERR_INVALID_ARGUMENTS = 6;
        /// <summary>
        /// 설정된 인식모델이 비정상적임
        /// </summary>
        public const int ERR_INVALID_MODEL = 7;
        /// <summary>
        /// 잘못된 객체에 접근
        /// </summary>
        public const int ERR_INVALID_INSTANCE = 8;
        /// <summary>
        /// 데모 기간/횟수 만료
        /// </summary>
        public const int ERR_EXPIRE_DEMO = 9;
        /// <summary>
        /// 엔진이 실행 중
        /// </summary>
        public const int ERR_ENGINE_BUSY = 10;
        /// <summary>
        /// 인증 실패
        /// </summary>
        public const int ERR_AUTHORIZATION_FAIL = 11;
        /// <summary>
        /// 엔진이 이미 존재함
        /// </summary>
        public const int ERR_ALREADY_EXIST = 12;

        // Recognition Mode ----------------------------------------------------
        /// <summary>
        /// 낱자 인식
        /// </summary>
        public const int SINGLECHAR = 0;
        /// <summary>
        /// 여러 글자 인식
        /// </summary>
        public const int MULTICHAR = 1;
        /// <summary>
        /// 겹쳐 쓴 글자 인식
        /// </summary>
        public const int OVERLAPCHAR = 2;
        /// <summary>
        /// 여러 줄로 된 글자 인식
        /// </summary>
        public const int MULTILINE = 3;

        // Language Mode -------------------------------------------------------
        /// <summary>
        /// 초등수학
        /// </summary>
        public const int DLANG_MATH_ELEMENTARY = 201;
        /// <summary>
        /// 중등수학
        /// </summary>
        public const int DLANG_MATH_MIDDLE = 202;
        /// <summary>
        /// 중등수학 확장
        /// </summary>
        public const int DLANG_MATH_MIDDLE_EXPANSION = 203;
        /// <summary>
        /// 화학식
        /// </summary>
        public const int DLANG_MATH_CHEMICAL = 204;

        // Language Type -------------------------------------------------------
        /// <summary>
        /// 타입 없음
        /// </summary>
        public const int DTYPE_NONE = (1 << 0);
        /// <summary>
        /// 초등수학
        /// </summary>
        public const int DTYPE_MATH_ET = (1 << 22);
        /// <summary>
        /// 중등수학
        /// </summary>
        public const int DTYPE_MATH_MD = (1 << 23);
        /// <summary>
        /// 중등수학 확장
        /// </summary>
        public const int DTYPE_MATH_EX = (1 << 24);
        /// <summary>
        /// 화학식
        /// </summary>
        public const int DTYPE_MATH_CF = (1 << 25);

        // Param type ----------------------------------------------------------
        public const int LOG_LEVEL = 0;
        public const int LOG_CALLBACK = 1;
        public const int WRITE_INK = 2;
        public const int LANG_MODEL = 3;

        // Log level -----------------------------------------------------------
        public const int LEVEL_NONE = 0;
        public const int LEVEL_ERROR = 1;
        public const int LEVEL_WARN = 2;
        public const int LEVEL_INFO = 3;
        public const int LEVEL_DEBUG = 4;

        // Main APIs -----------------------------------------------------------
        /// <summary>
        /// 인식엔진의 인스턴스를 생성함
        /// </summary>
        /// <param name="keyPath">[in] 파일명을 포함한 License key 파일의 경로</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRCreate")]
        public static extern int Create(String keyPath);

        /// <summary>
        /// 인식모드 속성 값을 설정함
        /// </summary>
        /// <param name="setting">[in] setting 설정이 완료된 Setting Object</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRSetAttribute")]
        public static extern int SetAttribute(IntPtr setting);

        /// <summary>
        /// 인식모드 속성 값에 따라 입력 데이터를 인식함
        /// </summary>
        /// <param name="ink">[in] ink 좌표가 입력된 Ink Object</param>
        /// <param name="result">[out] 인식된 결과가 저장된 Result Object</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRecognize")]
        public static extern int Recognize(IntPtr ink, IntPtr result);

        /// <summary>
        /// 인식엔진의 인스턴스를 소멸시킴
        /// </summary>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRClose")]
        public static extern int Close();

        // Optional APIs -------------------------------------------------------
        /// <summary>
        /// 엔진내부에서 사용하는 외부리소스(언어모델 파일 등)의 경로 설정
        /// </summary>
        /// <param name="path">[in] path 리소스 경로</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRSetExternalResourcePath")]
        public static extern int SetExternalResourcePath(String path);

        /// <summary>
        /// 엔진내부에서 사용하는 외부라이브러리의 경로 설정
        /// </summary>
        /// <param name="path">[in] path 외부라이브러리의 경로</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRSetExternalLibraryPath")]
        public static extern int SetExternalLibraryPath(String path);

        /// <summary>
        /// 특정 타입의 파라미터 값을 가져옴
        /// </summary>
        /// <param name="type">[in] 파라미터 타입</param>
        /// <param name="param">[out] 특정 파리미터 타입의 포인터</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetParam")]
        public static extern int GetParam(int type, [In, Out] ref int param);

        /// <summary>
        /// 특정 타입의 파라미터 값을 설정함
        /// </summary>
        /// <param name="type">[in] 파라미터 타입</param>
        /// <param name="param">[in] 특정 파리미터 타입의 포인터</param>
        /// <returns></returns>
        [DllImport("libspmath", EntryPoint = "DHWRSetParam")]
        public static extern int SetParam(int type, [In, Out] ref int param);

        /// <summary>
        /// 엔진의 빌드넘버 스트링의 포인터를 가져옴
        /// </summary>
        /// <param name="revision">[out] 엔진 빌드넘버</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetRevision")]
        public static extern int GetRevisionPtr(IntPtr[] revision);

        /// <summary>
        /// 엔진의 빌드넘버 스트링을 반환
        /// </summary>
        /// <returns>엔진의 빌드넘버 스트링</returns>
        public static String GetRevision()
        {
            IntPtr[] version = new IntPtr[1];
            Hwr.GetRevisionPtr(version);
            return Marshal.PtrToStringAnsi(version[0]);
        }

        /// <summary>
        /// License key에 설정된 엔진의 due date를 가져온다
        /// </summary>
        /// <param name="due_date">[out] 년월일을 나타내는 8자리의 integer 값 (ex 20161206)</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetDueDate")]
        public static extern int GetDueDate([In, Out] ref int due_date);

        // SettingObject APIs --------------------------------------------------
        /// <summary>
        /// 설정 오브젝트를 생성한다
        /// </summary>
        /// <returns>설정 오브젝트</returns>
        [DllImport("libspmath", EntryPoint = "DHWRCreateSettingObject")]
        public static extern IntPtr CreateSettingObject();

        /// <summary>
        /// 설정 오브젝트를 제거한다
        /// </summary>
        /// <param name="setting">[in] 설정 오브젝트</param>
        [DllImport("libspmath", EntryPoint = "DHWRDestroySettingObject")]
        public static extern void DestroySettingObject(IntPtr setting);

        /// <summary>
        /// 필기 인식 모드를 설정한다(낱자, 연속)
        /// </summary>
        /// <param name="setting"> [in] 설정 오브젝트</param>
        /// <param name="mode">[in] 인식 모드</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRSetRecognitionMode")]
        public static extern int SetRecognitionMode(IntPtr setting, int mode);

        /// <summary>
        /// 인식 후보 출력 크기를 설정한다
        /// </summary>
        /// <param name="setting">[in] 설정 오브젝트</param>
        /// <param name="size">[in] 후보수</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRSetCandidateSize")]
        public static extern int SetCandidateSize(IntPtr setting, int size);

        /// <summary>
        /// 인식할 언어를 추가 한다
        /// </summary>
        /// <param name="setting">[in] 설정 오브젝트</param>
        /// <param name="language">[in] 언어 값</param>
        /// <param name="option">[in] 따른 옵션</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRAddLanguage")]
        public static extern int AddLanguage(IntPtr setting, int language, int option);

        /// <summary>
        /// 설정된 언어 크기를 가져온다
        /// </summary>
        /// <param name="setting">[in] 설정 오브젝트</param>
        /// <param name="size">[out] 크기</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetLanguageSize")]
        public static extern int GetLanguageSize(IntPtr setting, [In, Out] ref int size);

        /// <summary>
        /// 설정된 언어를 초기화 한다
        /// </summary>
        /// <param name="setting">[in] 설정 오브젝트</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRClearLanguage")]
        public static extern int ClearLanguage(IntPtr setting);

        /// <summary>
        /// 인식할 심볼을 정의
        /// </summary>
        /// <param name="setting">[in] 설정 오브젝트</param>
        /// <param name="charset">[in] 인식할 심볼의 리스트</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRSetUserCharSet")]
        public static extern int SetUserCharSet(IntPtr setting, [In] ushort[] charset);

        // InkObject APIs ------------------------------------------------------
        /// <summary>
        /// 잉크 오브젝트를 생성한다
        /// </summary>
        /// <returns>잉크 오브젝트</returns>
        [DllImport("libspmath", EntryPoint = "DHWRCreateInkObject")]
        public static extern IntPtr CreateInkObject();

        /// <summary>
        /// 잉크 오브젝트를 제거한다
        /// </summary>
        /// <param name="ink">[in] 잉크 오브젝트</param>
        [DllImport("libspmath", EntryPoint = "DHWRDestroyInkObject")]
        public static extern void DestroyInkObject(IntPtr ink);

        /// <summary>
        /// 인식엔진에서 인식할 터치 좌표(잉크 좌표)를 추가함
        /// </summary>
        /// <param name="ink">[in] ink 잉크 오브젝트</param>
        /// <param name="x">[in] x좌표</param>
        /// <param name="y">[in] y좌표</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRAddPoint")]
        public static extern int AddPoint(IntPtr ink, int x, int y);

        /// <summary>
        /// TouchUp 이벤트에 의해 한 획의 입력을 마쳤을 때 호출함
        /// </summary>
        /// <param name="ink">[in] 잉크 오브젝트</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWREndStroke")]
        public static extern int EndStroke(IntPtr ink);

        /// <summary>
        /// 입력한 좌표 데이터를 초기화함
        /// </summary>
        /// <param name="ink">[in] 잉크 오브젝트</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRInkClear")]
        public static extern int InkClear(IntPtr ink);

        /// <summary>
        /// 입력된 잉크 인덱스 값에 해당하는 잉크 좌표값을 받아옴
        /// </summary>
        /// <param name="ink">[in] 잉크 오브젝트</param>
        /// <param name="index">[in] 받아오고자 하는 잉크의 인덱스</param>
        /// <param name="x">[out] 해당 잉크의 x좌표값</param>
        /// <param name="y">[out] 해당 잉크의 y좌표값</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetInkPoint")]
        public static extern int GetInkPoint(IntPtr ink, int index, [In, Out] ref int x, [In, Out] ref int y);

        /// <summary>
        /// 현재까지 입력된 잉크의 카운트
        /// </summary>
        /// <param name="ink">[in] 잉크 오브젝트</param>
        /// <param name="count">[out] 잉크 카운트</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetInkCount")]
        public static extern int GetInkCount(IntPtr ink, [In, Out] ref int count);

        // ResultObject APIs ---------------------------------------------------
        /// <summary>
        /// 결과 오브젝트를 생성한다
        /// </summary>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRCreateResultObject")]
        public static extern IntPtr CreateResultObject();

        /// <summary>
        /// 결과 오브젝트를 제거한다
        /// </summary>
        /// <param name="result">[in] 결과 오브젝트</param>
        [DllImport("libspmath", EntryPoint = "DHWRDestroyResultObject")]
        public static extern void DestroyResultObject(IntPtr result);

        /// <summary>
        /// 결과 값의 라인 크기를 가져온다
        /// </summary>
        /// <param name="ink">[in] 결과 오브젝트</param>
        /// <returns>Line Size</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetLineSize")]
        public static extern int GetLineSize(IntPtr ink);

        /// <summary>
        /// 지정된 인덱스의 라인 결과를 가져온다
        /// </summary>
        /// <param name="result">[in] 결과 오브젝트</param>
        /// <param name="index">[in] 라인 인덱스</param>
        /// <returns>라인 결과</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetLine")]
        public static extern IntPtr GetLine(IntPtr result, int index);

        /// <summary>
        /// 라인 결과 값의 블럭 크기를 가져온다
        /// </summary>
        /// <param name="line">[in] 라인 결과 값</param>
        /// <returns>Block Size</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetBlockSize")]
        public static extern int GetBlockSize(IntPtr line);

        /// <summary>
        /// 라인 결과 값의 지정된 인덱스의 블럭 결과를 가져온다
        /// </summary>
        /// <param name="line">[in] 라인</param>
        /// <param name="index">[in] 블럭 인덱스</param>
        /// <returns>블럭 결과</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetBlock")]
        public static extern IntPtr GetBlock(IntPtr line, int index);

        /// <summary>
        /// 블럭 결과 값의 처리된 획의 개수를 얻어온다
        /// </summary>
        /// <param name="block">[in] 블럭 결과 값</param>
        /// <returns>Stroke Size</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetStrokeSize")]
        public static extern int GetStrokeSize(IntPtr block);

        /// <summary>
        /// 블럭 결과값의 처리된 획의 인덱스들을 얻어온다
        /// </summary>
        /// <param name="block">[in] 블럭 결과 값</param>
        /// <param name="indices">[out] 인덱스 포인터</param>
        /// <param name="size">[in] 인덱스 포인터 사이즈</param>
        /// <returns>에러 코드 값</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetStrokeIndices")]
        public static extern int GetStrokeIndices(IntPtr block, [In, Out] ref int indices, int size);

        /// <summary>
        /// 블럭 결과 값에서 후보 크기를 가져온다
        /// </summary>
        /// <param name="block">[in] 블럭 결과 값</param>
        /// <returns>Candidate Size</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetCandidateSize")]
        public static extern int GetCandidateSize(IntPtr block);

        /// <summary>
        /// 블럭 결과 값에서 인식 후보문자의 포인터를 반환한다
        /// </summary>
        /// <param name="block">[in] 블럭 결과 값</param>
        /// <param name="index">[in] 후보 인덱스</param>
        /// <param name="length">[out] 인식후보 문자열 크기</param>
        /// <returns>후보문자의 포인터</returns>
        [DllImport("libspmath", EntryPoint = "DHWRGetCandidate")]
        public static extern IntPtr GetCandidatePtr(IntPtr block, int index, [In, Out] ref int length);

        /// <summary>
        /// 블럭 결과 값에서 인식된 후보문자를 반환한다
        /// </summary>
        /// <param name="block">[in] 블럭 결과 값</param>
        /// <param name="index">[in] 후보 인덱스</param>
        /// <param name="length">[out] 인식후보 문자열 크기</param>
        /// <returns>후보문자</returns>
        public static String GetCandidate(IntPtr block, int index, [In, Out] ref int length)
        {
            IntPtr candidatePtr = Hwr.GetCandidatePtr(block, index, ref length);
            StringBuilder candidates = new StringBuilder();

            if (length > 0)
            {
                String os = System.Environment.OSVersion.Platform.ToString();
                if (os.Contains("Win"))
                {
                    candidates.Append(Marshal.PtrToStringUni(candidatePtr, length));
                }
                else
                {
                    int[] buffers = new int[length];
                    Marshal.Copy(candidatePtr, buffers, 0, length);
                    foreach (uint buf in buffers)
                    {
                        candidates.Append(Convert.ToChar(buf));
                    }
                }
            }

            return candidates.ToString();
        }
    }
}
