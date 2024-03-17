import TopMenu from "../components/topMenu";
import MainMenu from "../components/MainMenu";
import SideBar from "../components/SideBar";
import Header from "../components/Header";

export default function Layout({
    children,
}: Readonly<{
    children: React.ReactNode;
}>) {
    return (
        <>
            <header>
                <TopMenu />
                <MainMenu />
            </header>
            <div className="flex h-[calc(100%_-_40px)] lg:h-[calc(100%_-_106px)]">
                <SideBar />
                <main className="w-[85vw] overflow-y-auto">{children}</main>
            </div>
        </>
    );
}
