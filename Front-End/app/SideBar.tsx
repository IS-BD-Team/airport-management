export default () => {
    return (
        <div className="overflow-y-auto py-4 px-3 bg-[#f6f6f9] dark:bg-gray-800 w-[280px] 
        shadow-inset -left-9 0 6 -6 rgba-0-0-0-5">
            <div>
                <span className="text-xl font-bold">Airport Management</span>
            </div>
            <ul className="sideBarList">
                <li>
                    <a href="/" className="flex items-center p-2 text-base font-normal text-gray-900 dark:text-white hover:bg-[#614ba6] hover:text-white dark:hover:bg-gray-700">
                        <span className="ml-3">Airports</span>
                    </a>
                </li>
                <li>
                    <a href="/" className="flex items-center p-2 text-base font-normal text-gray-900 dark:text-white hover:bg-[#614ba6] hover:text-white dark:hover:bg-gray-700">
                        <span className="ml-3">Services</span>
                    </a>
                </li>
                <li>
                    <a href="/" className="flex items-center p-2 text-base font-normal text-gray-900 dark:text-white hover:bg-[#614ba6] hover:text-white dark:hover:bg-gray-700">
                        <span className="ml-3">Installations</span>
                    </a>
                </li>
                <li>
                    <a href="/" className="flex items-center p-2 text-base font-normal text-gray-900 dark:text-white hover:bg-[#614ba6] hover:text-white dark:hover:bg-gray-700">
                        <span className="ml-3">Planes</span>
                    </a>
                </li>
                <li>
                    <a href="/" className="flex items-center p-2 text-base font-normal text-gray-900 dark:text-white hover:bg-[#614ba6] hover:text-white dark:hover:bg-gray-700">
                        <span className="ml-3">Clients</span>
                    </a>
                </li>
            </ul>
        </div>
    );
}