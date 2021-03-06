#region Translated by Jose Antonio De Santiago-Castillo.

//Translated by Jose Antonio De Santiago-Castillo.
//E-mail:JAntonioDeSantiago@gmail.com
//Website: www.DotNumerics.com
//
//Fortran to C# Translation.
//Translated by:
//F2CSharp Version 0.72 (Dicember 7, 2009)
//Code Optimizations: , assignment operator, for-loop: array indexes
//
#endregion

using System;
using DotNumerics.FortranLibrary;

namespace DotNumerics.LinearAlgebra.CSLapack
{
    /// <summary>
    /// -- LAPACK routine (version 3.1) --
    /// Univ. of Tennessee, Univ. of California Berkeley and NAG Ltd..
    /// November 2006
    /// Purpose
    /// =======
    /// 
    /// DORMQR overwrites the general real M-by-N matrix C with
    /// 
    /// SIDE = 'L'     SIDE = 'R'
    /// TRANS = 'N':      Q * C          C * Q
    /// TRANS = 'T':      Q**T * C       C * Q**T
    /// 
    /// where Q is a real orthogonal matrix defined as the product of k
    /// elementary reflectors
    /// 
    /// Q = H(1) H(2) . . . H(k)
    /// 
    /// as returned by DGEQRF. Q is of order M if SIDE = 'L' and of order N
    /// if SIDE = 'R'.
    /// 
    ///</summary>
    public class DORMQR
    {
    

        #region Dependencies
        
        LSAME _lsame; ILAENV _ilaenv; DLARFB _dlarfb; DLARFT _dlarft; DORM2R _dorm2r; XERBLA _xerbla; 

        #endregion


        #region Variables
        
        const int NBMAX = 64; const int LDT = NBMAX + 1; double[] T = new double[LDT * NBMAX]; 

        #endregion

        public DORMQR(LSAME lsame, ILAENV ilaenv, DLARFB dlarfb, DLARFT dlarft, DORM2R dorm2r, XERBLA xerbla)
        {
    

            #region Set Dependencies
            
            this._lsame = lsame; this._ilaenv = ilaenv; this._dlarfb = dlarfb; this._dlarft = dlarft; this._dorm2r = dorm2r; 
            this._xerbla = xerbla;

            #endregion

        }
    
        public DORMQR()
        {
    

            #region Dependencies (Initialization)
            
            LSAME lsame = new LSAME();
            IEEECK ieeeck = new IEEECK();
            IPARMQ iparmq = new IPARMQ();
            DCOPY dcopy = new DCOPY();
            XERBLA xerbla = new XERBLA();
            ILAENV ilaenv = new ILAENV(ieeeck, iparmq);
            DGEMM dgemm = new DGEMM(lsame, xerbla);
            DTRMM dtrmm = new DTRMM(lsame, xerbla);
            DLARFB dlarfb = new DLARFB(lsame, dcopy, dgemm, dtrmm);
            DGEMV dgemv = new DGEMV(lsame, xerbla);
            DTRMV dtrmv = new DTRMV(lsame, xerbla);
            DLARFT dlarft = new DLARFT(dgemv, dtrmv, lsame);
            DGER dger = new DGER(xerbla);
            DLARF dlarf = new DLARF(dgemv, dger, lsame);
            DORM2R dorm2r = new DORM2R(lsame, dlarf, xerbla);

            #endregion


            #region Set Dependencies
            
            this._lsame = lsame; this._ilaenv = ilaenv; this._dlarfb = dlarfb; this._dlarft = dlarft; this._dorm2r = dorm2r; 
            this._xerbla = xerbla;

            #endregion

        }
        /// <summary>
        /// Purpose
        /// =======
        /// 
        /// DORMQR overwrites the general real M-by-N matrix C with
        /// 
        /// SIDE = 'L'     SIDE = 'R'
        /// TRANS = 'N':      Q * C          C * Q
        /// TRANS = 'T':      Q**T * C       C * Q**T
        /// 
        /// where Q is a real orthogonal matrix defined as the product of k
        /// elementary reflectors
        /// 
        /// Q = H(1) H(2) . . . H(k)
        /// 
        /// as returned by DGEQRF. Q is of order M if SIDE = 'L' and of order N
        /// if SIDE = 'R'.
        /// 
        ///</summary>
        /// <param name="SIDE">
        /// = 'L'     SIDE = 'R'
        ///</param>
        /// <param name="TRANS">
        /// (input) CHARACTER*1
        /// = 'N':  No transpose, apply Q;
        /// = 'T':  Transpose, apply Q**T.
        ///</param>
        /// <param name="M">
        /// (input) INTEGER
        /// The number of rows of the matrix C. M .GE. 0.
        ///</param>
        /// <param name="N">
        /// (input) INTEGER
        /// The number of columns of the matrix C. N .GE. 0.
        ///</param>
        /// <param name="K">
        /// (input) INTEGER
        /// The number of elementary reflectors whose product defines
        /// the matrix Q.
        /// If SIDE = 'L', M .GE. K .GE. 0;
        /// if SIDE = 'R', N .GE. K .GE. 0.
        ///</param>
        /// <param name="A">
        /// (input) DOUBLE PRECISION array, dimension (LDA,K)
        /// The i-th column must contain the vector which defines the
        /// elementary reflector H(i), for i = 1,2,...,k, as returned by
        /// DGEQRF in the first k columns of its array argument A.
        /// A is modified by the routine but restored on exit.
        ///</param>
        /// <param name="LDA">
        /// (input) INTEGER
        /// The leading dimension of the array A.
        /// If SIDE = 'L', LDA .GE. max(1,M);
        /// if SIDE = 'R', LDA .GE. max(1,N).
        ///</param>
        /// <param name="TAU">
        /// (input) DOUBLE PRECISION array, dimension (K)
        /// TAU(i) must contain the scalar factor of the elementary
        /// reflector H(i), as returned by DGEQRF.
        ///</param>
        /// <param name="C">
        /// (input/output) DOUBLE PRECISION array, dimension (LDC,N)
        /// On entry, the M-by-N matrix C.
        /// On exit, C is overwritten by Q*C or Q**T*C or C*Q**T or C*Q.
        ///</param>
        /// <param name="LDC">
        /// (input) INTEGER
        /// The leading dimension of the array C. LDC .GE. max(1,M).
        ///</param>
        /// <param name="WORK">
        /// (workspace/output) DOUBLE PRECISION array, dimension (MAX(1,LWORK))
        /// On exit, if INFO = 0, WORK(1) returns the optimal LWORK.
        ///</param>
        /// <param name="LWORK">
        /// (input) INTEGER
        /// The dimension of the array WORK.
        /// If SIDE = 'L', LWORK .GE. max(1,N);
        /// if SIDE = 'R', LWORK .GE. max(1,M).
        /// For optimum performance LWORK .GE. N*NB if SIDE = 'L', and
        /// LWORK .GE. M*NB if SIDE = 'R', where NB is the optimal
        /// blocksize.
        /// 
        /// If LWORK = -1, then a workspace query is assumed; the routine
        /// only calculates the optimal size of the WORK array, returns
        /// this value as the first entry of the WORK array, and no error
        /// message related to LWORK is issued by XERBLA.
        ///</param>
        /// <param name="INFO">
        /// (output) INTEGER
        /// = 0:  successful exit
        /// .LT. 0:  if INFO = -i, the i-th argument had an illegal value
        ///</param>
        public void Run(string SIDE, string TRANS, int M, int N, int K, ref double[] A, int offset_a
                         , int LDA, double[] TAU, int offset_tau, ref double[] C, int offset_c, int LDC, ref double[] WORK, int offset_work, int LWORK
                         , ref int INFO)
        {

            #region Variables
            
            bool LEFT = false; bool LQUERY = false; bool NOTRAN = false; int I = 0; int I1 = 0; int I2 = 0; int I3 = 0; 
            int IB = 0;int IC = 0; int IINFO = 0; int IWS = 0; int JC = 0; int LDWORK = 0; int LWKOPT = 0; int MI = 0; int NB = 0; 
            int NBMIN = 0;int NI = 0; int NQ = 0; int NW = 0; int offset_t = 0;

            #endregion


            #region Array Index Correction
            
             int o_a = -1 - LDA + offset_a;  int o_tau = -1 + offset_tau;  int o_c = -1 - LDC + offset_c; 
             int o_work = -1 + offset_work;

            #endregion


            #region Strings
            
            SIDE = SIDE.Substring(0, 1);  TRANS = TRANS.Substring(0, 1);  

            #endregion


            #region Prolog
            
            // *
            // *  -- LAPACK routine (version 3.1) --
            // *     Univ. of Tennessee, Univ. of California Berkeley and NAG Ltd..
            // *     November 2006
            // *
            // *     .. Scalar Arguments ..
            // *     ..
            // *     .. Array Arguments ..
            // *     ..
            // *
            // *  Purpose
            // *  =======
            // *
            // *  DORMQR overwrites the general real M-by-N matrix C with
            // *
            // *                  SIDE = 'L'     SIDE = 'R'
            // *  TRANS = 'N':      Q * C          C * Q
            // *  TRANS = 'T':      Q**T * C       C * Q**T
            // *
            // *  where Q is a real orthogonal matrix defined as the product of k
            // *  elementary reflectors
            // *
            // *        Q = H(1) H(2) . . . H(k)
            // *
            // *  as returned by DGEQRF. Q is of order M if SIDE = 'L' and of order N
            // *  if SIDE = 'R'.
            // *
            // *  Arguments
            // *  =========
            // *
            // *  SIDE    (input) CHARACTER*1
            // *          = 'L': apply Q or Q**T from the Left;
            // *          = 'R': apply Q or Q**T from the Right.
            // *
            // *  TRANS   (input) CHARACTER*1
            // *          = 'N':  No transpose, apply Q;
            // *          = 'T':  Transpose, apply Q**T.
            // *
            // *  M       (input) INTEGER
            // *          The number of rows of the matrix C. M >= 0.
            // *
            // *  N       (input) INTEGER
            // *          The number of columns of the matrix C. N >= 0.
            // *
            // *  K       (input) INTEGER
            // *          The number of elementary reflectors whose product defines
            // *          the matrix Q.
            // *          If SIDE = 'L', M >= K >= 0;
            // *          if SIDE = 'R', N >= K >= 0.
            // *
            // *  A       (input) DOUBLE PRECISION array, dimension (LDA,K)
            // *          The i-th column must contain the vector which defines the
            // *          elementary reflector H(i), for i = 1,2,...,k, as returned by
            // *          DGEQRF in the first k columns of its array argument A.
            // *          A is modified by the routine but restored on exit.
            // *
            // *  LDA     (input) INTEGER
            // *          The leading dimension of the array A.
            // *          If SIDE = 'L', LDA >= max(1,M);
            // *          if SIDE = 'R', LDA >= max(1,N).
            // *
            // *  TAU     (input) DOUBLE PRECISION array, dimension (K)
            // *          TAU(i) must contain the scalar factor of the elementary
            // *          reflector H(i), as returned by DGEQRF.
            // *
            // *  C       (input/output) DOUBLE PRECISION array, dimension (LDC,N)
            // *          On entry, the M-by-N matrix C.
            // *          On exit, C is overwritten by Q*C or Q**T*C or C*Q**T or C*Q.
            // *
            // *  LDC     (input) INTEGER
            // *          The leading dimension of the array C. LDC >= max(1,M).
            // *
            // *  WORK    (workspace/output) DOUBLE PRECISION array, dimension (MAX(1,LWORK))
            // *          On exit, if INFO = 0, WORK(1) returns the optimal LWORK.
            // *
            // *  LWORK   (input) INTEGER
            // *          The dimension of the array WORK.
            // *          If SIDE = 'L', LWORK >= max(1,N);
            // *          if SIDE = 'R', LWORK >= max(1,M).
            // *          For optimum performance LWORK >= N*NB if SIDE = 'L', and
            // *          LWORK >= M*NB if SIDE = 'R', where NB is the optimal
            // *          blocksize.
            // *
            // *          If LWORK = -1, then a workspace query is assumed; the routine
            // *          only calculates the optimal size of the WORK array, returns
            // *          this value as the first entry of the WORK array, and no error
            // *          message related to LWORK is issued by XERBLA.
            // *
            // *  INFO    (output) INTEGER
            // *          = 0:  successful exit
            // *          < 0:  if INFO = -i, the i-th argument had an illegal value
            // *
            // *  =====================================================================
            // *
            // *     .. Parameters ..
            // *     ..
            // *     .. Local Scalars ..
            // *     ..
            // *     .. Local Arrays ..
            // *     ..
            // *     .. External Functions ..
            // *     ..
            // *     .. External Subroutines ..
            // *     ..
            // *     .. Intrinsic Functions ..
            //      INTRINSIC          MAX, MIN;
            // *     ..
            // *     .. Executable Statements ..
            // *
            // *     Test the input arguments
            // *

            #endregion


            #region Body
            
            INFO = 0;
            LEFT = this._lsame.Run(SIDE, "L");
            NOTRAN = this._lsame.Run(TRANS, "N");
            LQUERY = (LWORK ==  - 1);
            // *
            // *     NQ is the order of Q and NW is the minimum dimension of WORK
            // *
            if (LEFT)
            {
                NQ = M;
                NW = N;
            }
            else
            {
                NQ = N;
                NW = M;
            }
            if (!LEFT && !this._lsame.Run(SIDE, "R"))
            {
                INFO =  - 1;
            }
            else
            {
                if (!NOTRAN && !this._lsame.Run(TRANS, "T"))
                {
                    INFO =  - 2;
                }
                else
                {
                    if (M < 0)
                    {
                        INFO =  - 3;
                    }
                    else
                    {
                        if (N < 0)
                        {
                            INFO =  - 4;
                        }
                        else
                        {
                            if (K < 0 || K > NQ)
                            {
                                INFO =  - 5;
                            }
                            else
                            {
                                if (LDA < Math.Max(1, NQ))
                                {
                                    INFO =  - 7;
                                }
                                else
                                {
                                    if (LDC < Math.Max(1, M))
                                    {
                                        INFO =  - 10;
                                    }
                                    else
                                    {
                                        if (LWORK < Math.Max(1, NW) && !LQUERY)
                                        {
                                            INFO =  - 12;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // *
            if (INFO == 0)
            {
                // *
                // *        Determine the block size.  NB may be at most NBMAX, where NBMAX
                // *        is used to define the local array T.
                // *
                NB = Math.Min(NBMAX, this._ilaenv.Run(1, "DORMQR", SIDE + TRANS, M, N, K,  - 1));
                LWKOPT = Math.Max(1, NW) * NB;
                WORK[1 + o_work] = LWKOPT;
            }
            // *
            if (INFO != 0)
            {
                this._xerbla.Run("DORMQR",  - INFO);
                return;
            }
            else
            {
                if (LQUERY)
                {
                    return;
                }
            }
            // *
            // *     Quick return if possible
            // *
            if (M == 0 || N == 0 || K == 0)
            {
                WORK[1 + o_work] = 1;
                return;
            }
            // *
            NBMIN = 2;
            LDWORK = NW;
            if (NB > 1 && NB < K)
            {
                IWS = NW * NB;
                if (LWORK < IWS)
                {
                    NB = LWORK / LDWORK;
                    NBMIN = Math.Max(2, this._ilaenv.Run(2, "DORMQR", SIDE + TRANS, M, N, K,  - 1));
                }
            }
            else
            {
                IWS = NW;
            }
            // *
            if (NB < NBMIN || NB >= K)
            {
                // *
                // *        Use unblocked code
                // *
                this._dorm2r.Run(SIDE, TRANS, M, N, K, ref A, offset_a
                                 , LDA, TAU, offset_tau, ref C, offset_c, LDC, ref WORK, offset_work, ref IINFO);
            }
            else
            {
                // *
                // *        Use blocked code
                // *
                if ((LEFT && !NOTRAN) || (!LEFT && NOTRAN))
                {
                    I1 = 1;
                    I2 = K;
                    I3 = NB;
                }
                else
                {
                    I1 = ((K - 1) / NB) * NB + 1;
                    I2 = 1;
                    I3 =  - NB;
                }
                // *
                if (LEFT)
                {
                    NI = N;
                    JC = 1;
                }
                else
                {
                    MI = M;
                    IC = 1;
                }
                // *
                for (I = I1; (I3 >= 0) ? (I <= I2) : (I >= I2); I += I3)
                {
                    IB = Math.Min(NB, K - I + 1);
                    // *
                    // *           Form the triangular factor of the block reflector
                    // *           H = H(i) H(i+1) . . . H(i+ib-1)
                    // *
                    this._dlarft.Run("Forward", "Columnwise", NQ - I + 1, IB, ref A, I+I * LDA + o_a, LDA
                                     , TAU, I + o_tau, ref T, offset_t, LDT);
                    if (LEFT)
                    {
                        // *
                        // *              H or H' is applied to C(i:m,1:n)
                        // *
                        MI = M - I + 1;
                        IC = I;
                    }
                    else
                    {
                        // *
                        // *              H or H' is applied to C(1:m,i:n)
                        // *
                        NI = N - I + 1;
                        JC = I;
                    }
                    // *
                    // *           Apply H or H'
                    // *
                    this._dlarfb.Run(SIDE, TRANS, "Forward", "Columnwise", MI, NI
                                     , IB, A, I+I * LDA + o_a, LDA, T, offset_t, LDT, ref C, IC+JC * LDC + o_c
                                     , LDC, ref WORK, offset_work, LDWORK);
                }
            }
            WORK[1 + o_work] = LWKOPT;
            return;
            // *
            // *     End of DORMQR
            // *

            #endregion

        }
    }
}
