export default ()=>
{
    return(
        <div className="lg:w-full lg:flex lg:justify-between lg:text-[12px] 
        bg-[#002951] text-white px-2 hidden">
        
            <ul className="flex flex-row ">
                <li className="mr-2 list-none">
                    <a href="/">Home</a>
                </li>
                <li className="mr-2 list-none">
                    <a href="/">My Page</a>
                </li>
                <li className="mr-2 list-none">
                    <a href="/">Project</a>
                </li>
                <li className="list-none">
                    <a href="/">Report Server</a>
                </li>
            </ul>
            <div className="flex flex-row ">
            <div className="flex flex-row justify-between">
                <p className="mr-1.5">
                    Logged in as:
                </p>
                <a href="/">
                    ernesto.abt
                </a>
            </div>
            <ul className="flex flex-row">
                <li className="ml-4 list-none">
                    <a href="/">My Account</a>
                </li>
                <li className="ml-4 list-none">                
                    <a href="/">Sign Out</a>
                </li>
            </ul>
            </div>
        </div>
    )
}