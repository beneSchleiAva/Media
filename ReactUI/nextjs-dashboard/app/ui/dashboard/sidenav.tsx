'use client';
import Link from 'next/link';

import { PowerIcon } from '@heroicons/react/24/outline';
import React from 'react';

import {
  UserGroupIcon,
  HomeIcon,
  DocumentDuplicateIcon,
} from '@heroicons/react/24/outline';
import clsx from 'clsx';
import { usePathname } from 'next/navigation';

// Map of links to display in the side navigation.
// Depending on the size of the application, this would be stored in a database.
const links = [
  { name: 'Home', href: '/dashboard', icon: HomeIcon },
  {
    name: 'Invoices',
    href: '/dashboard/invoices',
    icon: DocumentDuplicateIcon,
  },
  { name: 'Products', href: '/dashboard/products', icon: UserGroupIcon },
  { name: 'Sign In', href: '/signin', icon: PowerIcon },
  { name: 'Sign Out', href: '/signout', icon: PowerIcon },
];

export default function SideNavigation() {
  const pathname = usePathname();

  return (
    <div className="flex flex-col gap-4 pt-4 p-4
			 items-center justify-start
             bg-gray-100">

      {links.map((link) => {
        const LinkIcon = link.icon;
        return (
          <Link
            key={link.name}
            href={link.href} className={clsx(
              'w-40 border-dashed border-2 border-indigo-600 flex h-[48px] grow items-center justify-center gap-2 rounded-md bg-gray-50 p-3 text-sm font-medium hover:bg-sky-100 hover:text-blue-600 md:flex-none md:justify-start md:p-2 md:px-3',
              {
                'bg-sky-100 text-blue-600': pathname === link.href,
              },
            )} >
            <LinkIcon className="w-6" />
            <p className="hidden md:block">{link.name}</p>
          </Link>
        );
      })}
    </div>)
};


