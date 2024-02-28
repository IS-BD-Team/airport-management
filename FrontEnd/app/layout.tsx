import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import TopMenu from "./topMenu";
import Header from "./Header";
import MainMenu from "./MainMenu";

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
        <html lang="en">
            <body className={inter.className}>
                <header>
                    <TopMenu />
                    <Header />
                    <MainMenu />
                </header>
                {children}
            </body>
        </html>
    );
}
