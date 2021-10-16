//Microsoft (R) C/C++ Optimizing Compiler Version 19.00.23506 for x64

#include <iostream>
#include <algorithm>
#include <cstdint>
using namespace std;
using mytype = uint16_t;

class RC5
{
    public:
    const int W = 16;
    const int R = 16;

    //const UInt64 PW = 0xB7E151628AED2A6B;   
    //const UInt64 QW = 0x9E3779B97F4A7C15;
    const mytype PW = 0xB7E1;
    const mytype QW = 0x9E37;

    mytype* L;
    mytype* S;
    int t;
    int b;        
    int u;   
    int c;

    RC5(unsigned char key[], int keyLength)
    {
        mytype x, y;
        int i, j, n;

        u = W >> 3;
        b = keyLength;
        c = b % u > 0 ? b / u + 1 : b / u;
        L = new mytype[c];

        for (i = b - 1; i >= 0; i--)
        {
            L[i / u] = ROL(L[i / u], 8) + key[i];
        }

        t = 2 * (R + 1);
        S = new mytype[t];
        S[0] = PW;
        for (i = 1; i < t; i++)
        {
            S[i] = S[i - 1] + QW;
        }

        x = y = 0;
        i = j = 0;
        n = 3 * std::max(t, c);

        for (int k = 0; k < n; k++)
        {
            x = S[i] = ROL((S[i] + x + y), 3);
            y = L[j] = ROL((L[j] + x + y), (int)(x + y));
            i = (i + 1) % t;
            j = (j + 1) % c;
        }
    }

    mytype ROL(mytype a, int offset)
    {
        mytype r1, r2;
        r1 = a << offset;
        r2 = a >> (W - offset);
        return (r1 | r2);

    }

    mytype ROR(mytype a, int offset)
    {
        mytype r1, r2;
        r1 = a >> offset;
        r2 = a << (W - offset);
        return (r1 | r2);

    }

    static mytype BytesToUInt64(unsigned char b[], int p)
    {
        mytype r = 0;
        for (int i = p + 7; i > p; i--)
        {
            r |= (mytype)b[i];
            r <<= 8;
        }
        r |= (mytype)b[p];
        return r;
    }

    static void UInt64ToBytes(mytype a, unsigned char b[], int p)
    {
        for (int i = 0; i < 7; i++)
        {
            b[p + i] = (unsigned char)(a & 0xFF);
            a >>= 8;
        }
        b[p + 7] = (unsigned char)(a & 0xFF);
    }

    void Cipher(unsigned char inBuf[], unsigned char outBuf[])
    {
        mytype a = BytesToUInt64(inBuf, 0);
        mytype b = BytesToUInt64(inBuf, W / 8);

        a = a + S[0];
        b = b + S[1];

        for (int i = 1; i < R + 1; i++)
        {
            a = ROL((a ^ b), (int)b) + S[2 * i];
            b = ROL((b ^ a), (int)a) + S[2 * i + 1];
        }

        UInt64ToBytes(a, outBuf, 0);
        UInt64ToBytes(b, outBuf, W / 8);
    }

    void Decipher(unsigned char inBuf[], unsigned char outBuf[])
    {
        mytype a = BytesToUInt64(inBuf, 0);
        mytype b = BytesToUInt64(inBuf, W / 8);

        for (int i = R; i > 0; i--)
        {
            b = ROR((b - S[2 * i + 1]), (int)a) ^ a;
            a = ROR((a - S[2 * i]), (int)b) ^ b;
        }

        b = b - S[1];
        a = a - S[0];

        UInt64ToBytes(a, outBuf, 0);
        UInt64ToBytes(b, outBuf, W / 8);
    }
};

int main()
{
    unsigned char m_Test[9] = "password";
    RC5 r(m_Test, 9);
    unsigned char input[4] = "Rom";
    unsigned char output[4];
    unsigned char decOutput[4];
    
    r.Cipher(input, output);
    r.Decipher(output, decOutput);
    
    std::cout << decOutput;
}