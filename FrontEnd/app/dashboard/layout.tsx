import TopMenu from "../components/topMenu";
import MainMenu from "../components/MainMenu";
export default function Layout({
    children,
}: Readonly<{
    children: React.ReactNode;
}>) {
    return (<>
            <header>
                <TopMenu />
                <MainMenu />
            </header>            
        <div>{children}</div>
        </>
    );
}