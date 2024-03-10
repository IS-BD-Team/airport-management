import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import TopMenu from "./components/topMenu";
import Header from "./components/Header";
import MainMenu from "./components/MainMenu";
import SideBar from "./components/SideBar";

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
                    <TopMenu />
                    <Header />
                    <MainMenu />
                </header>
                <div className="flex h-[calc(100%_-_40px)] lg:h-[calc(100%_-_106px)]">
                    <SideBar />
                    <main className="w-[85vw] p-5 overflow-y-auto">{children}</main>
                </div>
            </body>
        </html>
    );
}
