import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import Header from "./components/Header";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
    title: "Aeropuertos",
    description: "Proyecto de Ingeniería de Software",
};

export default function RootLayout({
    children,
}: Readonly<{
    children: React.ReactNode;
}>) {
    return (
        <html lang="en" >
            <head>
                <link rel="icon" href="./favicon.png" />
            </head>
            <body className={inter.className}>
                <header>
                    <Header />
                </header>
                {children}
            </body>
        </html>
    );
}
