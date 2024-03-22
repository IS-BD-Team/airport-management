import { NextResponse } from 'next/server'
import type { NextRequest } from 'next/server'

export async function middleware(request:NextRequest) {
    const response = await fetch('http://localhost:5258/auth/check',
    {
        method: "GET",
        headers: {
            Authorization:
                "Bearer " + request.cookies.get('UserToken')?.value,
        },
    })
    const status = await response.status;
    if (status === 200) {
        return NextResponse.next()
    }
    return NextResponse.redirect(new URL('/login', request.url));
    // return NextResponse.next();
}

export const config = {
    matcher:['/dashboard/:path*', '/', '/dashboard/Home'],
}