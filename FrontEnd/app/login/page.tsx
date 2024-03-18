'use client'
import { useRouter } from 'next/navigation';
import { FormEvent } from 'react';

const Login: React.FC = () => {  
  const router = useRouter();

  const handleSubmit = async(event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    // Add logic to process login here
    const email = event.currentTarget.userEmail.value;
    const password = event.currentTarget.password.value;

    const response = await fetch("http://localhost:5258/auth/login", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({email, password}),
    })

    const data = await response.json();
    console.log(response);
    console.log(data);

    if (response.status === 200) {
      // const serialized = serialize('UserToken', data.token, {
      //   httpOnly: true,
      //   maxAge: 60 * 60 * 24 * 7,
      //   path: "/",
      // })
      // console.log(serialized);
      document.cookie = `UserToken=${data.token};path='/';max-age=604800`;
      document.cookie = `UserEmail=${data.email};path='/';max-age=604800`;
      document.cookie = `UserName=${data.firstName};path='/';max-age=604800`;

      console.log(document.cookie);
      
      router.push('../dashboard/Home')
    }
    else
    {
      alert('Login failed');
    }
    
  };

  return (
    <form onSubmit={handleSubmit} className="flex flex-col p-4 max-w-sm mx-auto mt-10 space-y-4 bg-white shadow-md rounded-lg">
      <div>
        <label htmlFor="eserEmail" className="block text-sm font-medium text-gray-700">Username</label>
        <input
          id="userEmail"
          type="email"
          className="mt-1 block w-full px-3 py-2 bg-gray-50 border border-gray-300 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
        />
      </div>
      <div>
        <label htmlFor="password" className="block text-sm font-medium text-gray-700">Password</label>
        <input
          id="password"
          type="password"
          className="mt-1 block w-full px-3 py-2 bg-gray-50 border border-gray-300 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
        />
      </div>
      <button type="submit" className="px-4 py-2 bg-indigo-600 text-white font-semibold rounded-md hover:bg-indigo-700 focus:outline-none focus:bg-indigo-700">Log in</button>
    </form>
  );
};

export default Login;
