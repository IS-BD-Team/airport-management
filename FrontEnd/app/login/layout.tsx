import Header from "../components/Header";

export default function Layout({
    children,
}: Readonly<{
    children: React.ReactNode;
}>) {
    return (
        <>
            <header>
                <Header />
            </header>
            <div>{children}</div>
        </>
    );
}
