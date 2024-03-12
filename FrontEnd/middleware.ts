import { NextResponse } from 'next/server'
import type { NextRequest } from 'next/server'
import {jwtVerify} from  "jose";
export async function middleware(request:NextRequest) {
    const jwt = request.cookies.get("userToken");
    console.log(jwt);
    if (jwt===undefined) {
        return NextResponse.redirect(new URL("/login", request.url));
    }
    try {
        const {payload} = await jwtVerify(String(jwt), new TextEncoder().encode('secret'));
        console.log(payload);
        return NextResponse.next();
    } catch (error) {
        console.log(error);
        return NextResponse.redirect(new URL("/login", request.url));
    }
}
export const config = {
    matcher:['/dashboard/:path*', '/']
}