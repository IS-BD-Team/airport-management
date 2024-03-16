import { NextResponse } from 'next/server'
import type { NextRequest } from 'next/server'
export async function middleware(request:NextRequest) {
    const {status} = await NextResponse.next()
    if (status === 200) {
        return NextResponse.next()
    }
    return NextResponse.redirect(new URL('/login', request.url))
}
export const config = {
    matcher:['/dashboard/:path*', '/']
}